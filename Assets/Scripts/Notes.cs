using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.GraphicsBuffer;

public class Notes : MonoBehaviour
{
    public GameObject Note;
    public GameObject player;
    //int Collectable=0;
    public string noteID;
    public TMPro.TMP_Text collectedNotes;
    public GameObject Notelight;




    private void Start() 
    {
        if (GameManager.Instance != null && GameManager.Instance.IsNoteCollected(noteID))
        {
            gameObject.SetActive(false);
        }
    }

    public void DotweenAni()
    {
        Destroy(Notelight);

        transform.DOMove(collectedNotes.transform.position, 0.8f).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            Destroy(gameObject);
            Debug.Log("game object got destryed");
        });

        
        

        

    }








    // Update is called once per frame
    void Update()
    {
        
    }
}
