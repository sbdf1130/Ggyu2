// 플레이어 이동시 자취 남겨주는 스크립트

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailRender : MonoBehaviour
{
    float timeBtwSpawns = 0;
    public float startTimeBtwSpawns;
    Rigidbody2D PlayerR;
    public GameObject Trail;

    // Use this for initialization
    void Start()
    {
        PlayerR = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((int)PlayerR.velocity.y != 0 || (int)PlayerR.velocity.x != 0) // 중력 작용될때
        {
            if (timeBtwSpawns <= 0) // 음수라면 startTime값으로 대입되어지고 트레일 생성
            {
                GameObject instance = (GameObject)Instantiate(Trail, transform.position, Quaternion.identity);
                Destroy(instance, 0.5f);
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else // 양수라면 음수가 될때까지 지속적인 감소
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }

    }
}
