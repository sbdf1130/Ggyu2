using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour {

    // 목표점수 StarNum에 현재 StageStarNum이 도달시 다음 스테이지로 넘어가는 스크립트

    public int StageStarNum;
    public static int StarNum = 0;
    
	void Update ()
    {
        // 스테이지 클리어
	    if(StarNum == StageStarNum)
        {
            StarNum = 0;
            
            // 스테이지 넘어가기
            Debug.Log("스테이지 클리어");
        }
	}
}
