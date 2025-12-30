using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followspeed = 2f;
    public Transform target;
    public float yfloat = 1f;


    void Update()
    {
        Vector3 newpos = new Vector3(target.position.x, target.position.y + yfloat, -10f);
        transform.position = newpos;
    }
}
