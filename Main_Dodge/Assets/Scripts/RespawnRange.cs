// 참고 : [Unity] 특정 범위 내에서 랜덤한 위치에 오브젝트 스폰하기

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnRange : MonoBehaviour
{
    public GameObject rangeObject;
    BoxCollider rangeCollider;

    private void Awake()
    {
        rangeCollider = rangeObject.GetComponent<BoxCollider>();
    }

    Vector3 Return_RandomPosition()
    {
        Vector3 originPosition = rangeObject.transform.position;

        float range_X = rangeCollider.bounds.size.x;
        float range_Z = rangeCollider.bounds.size.z;

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Z = Random.Range((range_Z / 2) * -1, range_Z / 2);
        Vector3 RandomPostion = new Vector3(range_X, 0f, range_Z);

        Vector3 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;
    }

    public GameObject capsul;
    void Start()
    {
        StartCoroutine(RandomRespawn_Coroutine());
    }

    IEnumerator RandomRespawn_Coroutine()
    {
        while (true) 
        {
            yield return new WaitForSeconds(1f);

            GameObject instantCapsul = Instantiate(capsul, Return_RandomPosition(), Quaternion.identity);
            Destroy(instantCapsul, 5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
