using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotation : MonoBehaviour
{
    /* ���콺 / ���̽�ƽ�� �̿��� ī�޶� ������ �̵��ϴ� �ڵ�.
       ��Ʈ�ѷ��� �������� X,Y ���� ������ ī�޶��� eulerAngles�� �����Ͽ� ������ �̵� 
       Mathf.Clamp�� �̿��Ͽ� �ϴ�, ���� ������ �� -90~90�� ������ �ɾ �� ���� ���� �ʵ��� �Ѵ�.
       - https://kjun.kr/2118 - ����*/

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
