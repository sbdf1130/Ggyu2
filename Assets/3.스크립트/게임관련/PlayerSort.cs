// 플레이어 위치를 규격에 맞춰 정렬해주는 스크립트

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 플레이어의 위치를 소수점 반올림 하는 스크립트

public class PlayerSort : MonoBehaviour
{
    Rigidbody2D rgdy;
    GameObject Camera;
    Vector3 originPos;
    PlayerRotation PR;
    public Sprite Sp;
    SpriteRenderer SR;
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        rgdy = GetComponent<Rigidbody2D>();
        Camera = GameObject.Find("MainCamera");
        originPos = Camera.transform.localPosition;
        PR = GetComponent<PlayerRotation>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        rgdy.gravityScale = 0;
        transform.position = new Vector3(Mathf.Ceil(transform.position.x) - 0.5f,
            Mathf.Ceil(transform.position.y) - 0.5f, transform.position.z);
        rgdy.constraints = RigidbodyConstraints2D.None;
        rgdy.isKinematic = true;
        if (PR.dir == 0) //하
        {
            transform.rotation = Quaternion.Euler(0, 0, 0f);
        }
        else if (PR.dir == 1) //좌
        {
            transform.rotation = Quaternion.Euler(0, 0, -90f);
        }
        else if (PR.dir == 2) //상
        {
            transform.rotation = Quaternion.Euler(0, 0, 180f);
        }
        else if (PR.dir == 3) //우
        {
            transform.rotation = Quaternion.Euler(0, 0, 90f);
        }
        PR.ani.enabled = false;
        SR.sprite = Sp;
        StartCoroutine(Shake(0.1f, 0.2f));
    }
    void Update()
    {
        //transform.rotation = Quaternion.identity;
    }
    public IEnumerator Shake(float _amount, float _duration)
    {
        float timer = 0;
        while (timer <= _duration)
        {
            Camera.transform.localPosition = (Vector3)Random.insideUnitCircle * _amount + originPos;

            timer += Time.deltaTime;
            yield return null;
        }
        Camera.transform.localPosition = originPos;
    }
}
