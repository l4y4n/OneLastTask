using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseGameUI;
    [SerializeField] private AudioSource click;
    [SerializeField] private Slider volumeSlider;
    public float defaultVolume = 1f;



    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            load();
        }
        else
        {
            load();
        }
    }

    public void Resume()
    {
        AudioManager.Instance.PlayClick();
        //click.Play();
        PauseGameUI.SetActive(false);
        Time.timeScale = 1; 
        GameIsPaused = false;

    }

    public void Pause()
    {
        AudioManager.Instance.PlayClick();
        //click.Play();
        PauseGameUI.SetActive(true);
        Time.timeScale = 0; 
        GameIsPaused = true;
    }

    public void MainMenu()
    {
        AudioManager.Instance.PlayClick();
        //click.Play();
        Time.timeScale = 1f;   
        SceneManager.LoadScene(0); 
    }

    public void SetVolume(float value)
    {
        AudioListener.volume = volumeSlider.value;
        save();
    }

    private void save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

    private void load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    

}
