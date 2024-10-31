using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    Rigidbody rb;

    public GameObject effect;
    public GameObject effect2;

    public AudioClip sound1;
    public AudioClip sound2;

    public AudioSource audio;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;

        Destroy(gameObject, 6f);
    }

   
    void Update()
    {
        
    }

 
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController pc = other.GetComponent<PlayerController>();

            if (pc != null) 
            {
                audio.PlayOneShot(sound1);

                Instantiate(effect, transform.position, Quaternion.identity);
                pc.Die();
            }
        }
    }
}
