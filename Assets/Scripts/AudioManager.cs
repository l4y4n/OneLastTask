using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource clickSource;  
    public AudioClip clickClip;      

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayClick()
    {
        if (clickSource != null && clickClip != null)
        {
            clickSource.PlayOneShot(clickClip);
        }
        else
        {
            Debug.Log("AudioManager not working");
        }
    }
}
