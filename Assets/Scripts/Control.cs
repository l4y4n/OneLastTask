using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public static Control game;
    private void Awake()
    {
        if(game == null)
        {
            game=this;
            DontDestroyOnLoad(gameObject);
        }
        else if (game != this)
        {
            Destroy(gameObject);

        }
    }
}
