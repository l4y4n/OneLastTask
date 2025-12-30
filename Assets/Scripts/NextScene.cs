using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{

    public int sceneBuildIndex;
    public string exitPointName;
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            print("Switching scenes to" + sceneBuildIndex);
            if (GameManager.Instance != null)
            {
                GameManager.Instance.lastExitPoint = exitPointName;
            }
            SceneManager.LoadScene(sceneBuildIndex);
            
        }
    }
}
