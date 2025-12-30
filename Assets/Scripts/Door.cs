using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField] private AudioSource open;
    [SerializeField] private AudioSource close;

    public GameObject Door1;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Door1 != null && open != null)
        {
            
            Door1.SetActive(false);
            open.Play();
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Door1 != null && close != null)
        {
            Door1.SetActive(true);
            close.Play();
        }

    }
}
