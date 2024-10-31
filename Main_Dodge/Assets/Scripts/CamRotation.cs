using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotation : MonoBehaviour
{
    /* 마우스 / 조이스틱을 이용한 카메라 시점을 이동하는 코드.
       컨트롤러의 움직임을 X,Y 값을 가져와 카메라의 eulerAngles을 변경하여 시점을 이동 
       Mathf.Clamp를 이용하여 하늘, 땅을 보았을 때 -90~90도 제한을 걸어서 한 바퀴 돌지 않도록 한다.
       - https://kjun.kr/2118 - 참고*/

    public float rotSpeed = 200f;
    public VariableJoystick joystick;

    float mx = 0;
    float my = -35;

    void Start()
    {
       
    }

    
    void Update()
    {
        float x = joystick.Horizontal;
        float y = joystick.Vertical;

        mx += x * rotSpeed * Time.deltaTime;
        my += y * rotSpeed * Time.deltaTime;

        my = Mathf.Clamp(my, -90, 90);

        transform.eulerAngles = new Vector3(-my, mx, 0);
    }
}
