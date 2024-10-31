using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCamera : MonoBehaviour
{
    public float xcamera;
    public float ycamera;
    public float zcamera;
    Transform p;
    void Start()
    {
        p = GameObject.Find("Player").transform;
    }

    
    void Update()
    {
        transform.position = p.position + new Vector3(xcamera, ycamera, zcamera);
    }
}
