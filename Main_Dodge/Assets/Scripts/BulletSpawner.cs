using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float rateMin;
    public float rateMax;

    Transform target;
    float spawnRate;
    float timeAfterSpawn;


    void Start()
    {
        timeAfterSpawn = 0;
        spawnRate = Random.Range(rateMin, rateMax);
        target = FindObjectOfType<PlayerController>().transform;

    }

 
    void Update()
    {
        transform.LookAt(target);

        timeAfterSpawn += Time.deltaTime;
        if(timeAfterSpawn > spawnRate) 
        {
            timeAfterSpawn = 0f;

            GameObject obj =
                Instantiate(prefab, transform.position, transform.rotation);

            obj.transform.LookAt(target);

            spawnRate = Random.Range(rateMin, rateMax);
        }
    }
}
