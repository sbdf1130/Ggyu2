using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarHole : MonoBehaviour {
    
    // 플레이어에 - 별구멍이 닿을시 StarNum상승 및 별이 빛나게하는 메소드를 간접실행

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "starOff")
        {
            col.transform.tag = "starOn";
            col.GetComponent<StarOn>().Shine();
            GameMgr.StarNum++;
            Debug.Log("starOn");
        }
    }
}
