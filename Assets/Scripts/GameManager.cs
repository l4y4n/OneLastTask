using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public HashSet<string> collectedNotes = new HashSet<string>();
    public int papersCollected = 0;
    public string lastExitPoint = "";
    //public GameObject Note;

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

    public void CollectNote(string noteID)
    {
        if (!collectedNotes.Contains(noteID))
        {
            collectedNotes.Add(noteID);
            papersCollected++;

            Debug.Log("Collected " + papersCollected + " notes");

            if (papersCollected == 5)
            {
                SceneManager.LoadScene(6);
            }
        }
    }
    public void ResetProgress()
    {
        collectedNotes.Clear();
        papersCollected = 0;
        lastExitPoint = "";
        Debug.Log("Game progress reset!");
    }

    public bool IsNoteCollected(string noteID)
    {
        return collectedNotes.Contains(noteID);
    }

    
    


}
