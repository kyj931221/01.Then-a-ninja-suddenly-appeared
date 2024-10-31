using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody PlayerRigidbody;
    public float speed = 8f;

    public VariableJoystick joystick;

    
    void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {

        //float xInput = Input.GetAxis("Horizontal"); //수평선 : 수평방향의 축 값
        //float zInput = Input.GetAxis("Vertical"); //수직선 : 수직방향의 축 값

        float xInput = joystick.Horizontal;
        float zInput = joystick.Vertical;

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVel = new Vector3(xSpeed, 0f, zSpeed);
        PlayerRigidbody.velocity = newVel;

        transform.LookAt(newVel); //플레이어 조작 방향 바라보기

    }
    public void Die()
    {
        gameObject.SetActive(false);
        
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();

    }
}
