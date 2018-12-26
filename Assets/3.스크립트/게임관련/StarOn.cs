using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 플레이어가 별구멍 도달시 별구멍이 바뀌는 스크립트

public class StarOn : MonoBehaviour {

    Animator ani;
    public float dest;
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // 별구멍 빛나게 하는 메소드
	public void Shine()
    {
        ani.enabled = true;
        Destroy(gameObject,dest);
    }
}
