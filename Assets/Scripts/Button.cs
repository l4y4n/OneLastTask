using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [SerializeField] private AudioSource click;


    public void PlayGame()
    {
        AudioManager.Instance.PlayClick();
        //click.Play();
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ResetProgress();
        }
        SceneManager.LoadScene(7);
    }

    public void Credits()
    {
        AudioManager.Instance.PlayClick();
        //click.Play();
        SceneManager.LoadScene(8);
    }

    public void Intro()
    {
        AudioManager.Instance.PlayClick();
        //click.Play();
        SceneManager.LoadScene(1);
    }

    public void TryAgain()
    {
        AudioManager.Instance.PlayClick();
        //click.Play();
        SceneManager.LoadScene(0);
    }

    public void GameQuit()
    {
        AudioManager.Instance.PlayClick();
        //click.Play();
        Application.Quit();
        Debug.Log("Quit");
    }

   


}
