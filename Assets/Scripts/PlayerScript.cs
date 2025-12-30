using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    
    [SerializeField] private int speed = 5;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Notes n;
    bool Trigger = false;
    //int PaperCollected = 0;
    public GameObject Note;
    [SerializeField] private FloatSO scoreSO;
    [SerializeField] private TMPro.TMP_Text ScoreText;
    private Animator animator;

  




    void Start()
    {
        if (GameManager.Instance != null && !string.IsNullOrEmpty(GameManager.Instance.lastExitPoint))
        {
            string spawnName =  GameManager.Instance.lastExitPoint;
            GameObject spawnPoint = GameObject.Find(spawnName);

            if (spawnPoint != null)
            {
                transform.position = spawnPoint.transform.position;
                Debug.Log("Spawned at: " + spawnName);
            }
            else
            {
                Debug.LogWarning("No spawn point found for: " + spawnName);
            }
        }
    }

    void Update()
    {
        /* if (Input.GetKeyDown(KeyCode.F) && Trigger == true)
         {
             PaperCollected= PaperCollected +1;
             Debug.Log("PaperCollected = " + PaperCollected);
             Note.SetActive(false);
             Destroy(Note);
             n.CallEvent();

         }*/
        ScoreText.text = scoreSO.Value + "";
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
       
    }

    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);

            animator.SetBool("IsWalking", true);
        } else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(movement * speed);
        ScoreText.text = scoreSO.Value + "";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Notes>(out n))
        {
            Trigger = true;
            GameManager.Instance.CollectNote(n.noteID);
            //n.DotweenAni();
            //n.DotweenAnimation(ScoreText.transform);
            //Destroy(collision.gameObject);

            scoreSO.Value = scoreSO.Value + 1;
            ScoreText.text = scoreSO.Value + "";

            if (scoreSO.Value == 5)
            {
                SceneManager.LoadScene(6);
                scoreSO.Value = 0;
            }
            else
            {
                n.DotweenAni();
            }
            
            
                
            
            
        }
    }
   

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Notes>(out n))
        {
            Trigger = false;
            
        }


    }
}
