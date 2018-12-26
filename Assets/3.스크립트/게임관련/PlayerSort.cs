// 플레이어 위치를 규격에 맞춰 정렬해주는 스크립트

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 플레이어의 위치를 소수점 반올림 하는 스크립트

public class PlayerSort : MonoBehaviour
{
    Rigidbody2D rgdy;

    void Start()
    {
        rgdy = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        rgdy.gravityScale = 0;
        transform.position = new Vector3(transform.position.x, Mathf.Ceil(transform.position.y) - 0.5f, transform.position.z);
    }
    void Update()
    {
        transform.rotation = Quaternion.identity;
    }
}
