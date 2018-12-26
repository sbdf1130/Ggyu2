using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 플레이어가 별구멍 도달시 별구멍이 바뀌는 스크립트

public class StarOn : MonoBehaviour {

    public Sprite starOn;
    SpriteRenderer SR;

    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // 별구멍 빛나게 하는 메소드
	public void Shine()
    {
        SR.sprite = starOn;
    }
}
