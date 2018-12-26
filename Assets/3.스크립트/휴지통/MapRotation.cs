// 키를 눌러 맵을 회전시키는 스크립트

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRotation : MonoBehaviour
{
    private Vector2 startTP, endTP;
    public GameObject Player;
    Rigidbody2D PlayerR;
    bool isPlayer;   // 플레이어 큐브가 움직일 때 입력을 못받게 하기위한 변수
    bool isCube; // 맵 큐브가 회전할 때 입력을 못받게 하기위한 변수
    float cool; // 연속으로 입력받지 못하게 쿨타임 변수

    int dir;

    void Start()
    {
        dir = 0;
        PlayerR = Player.GetComponent<Rigidbody2D>();
        isPlayer = true;
        isCube = true;
        cool = 0.7f;
    }

    void FixedUpdate()
    {
        if ((int)PlayerR.velocity.y != 0 || (int)PlayerR.velocity.x != 0)
        {
            isPlayer = false;
            cool = 0f;
        }
        else
            isPlayer = true;

        if (cool < 0.4f)
            cool += Time.deltaTime;


        if(dir == 0)
        {
            Physics2D.gravity = new Vector2(0f, -20f);
            Debug.Log("하");
        }
        else if(dir ==1)
        {
            Physics2D.gravity = new Vector2(-20f, 0f);
            Debug.Log("좌");
        }
        else if(dir ==2)
        {
            Physics2D.gravity = new Vector2(0f, 20f);
            Debug.Log("상");
        }
        else if(dir ==3)
        {
            Physics2D.gravity = new Vector2(20f, 0f);
            Debug.Log("우");
        }
        else if(dir==4)
        {
            dir = 0;
        }
        else if(dir==-1)
        {
            dir = 3;
        }
    }

    public void left() // 모바일용 회전
    {
        StartCoroutine("LR");
        dir++;
    }
    public void right() // 모바일용 회전
    {
        StartCoroutine("RR");
        dir--;
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTP = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTP = Input.GetTouch(0).position;
            if (endTP.x - startTP.x > 100f)
            {
                left();
            }
            if (startTP.x - endTP.x > 100f)
            {
                right();
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) // PC용 회전
        {
            left();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) // PC용 회전
        {
            right();
        }
    }
    
    IEnumerator RightRot() //우회전
    {
        PlayerR.gravityScale = 1;
        int countTime = 0;
        while (countTime < 10)
        {
            transform.Rotate(0, 0, -9);
            yield return new WaitForSeconds(0.005f);
            countTime++;
        }
        Player.transform.Rotate(0, 0, 90, Space.Self);
        PlayerR.isKinematic = false;
        isCube = true;
        yield return null;
    }
    IEnumerator LeftRot() //좌회전
    {
        PlayerR.gravityScale = 1;
        int countTime = 0;
        while (countTime < 10)
        {
            transform.Rotate(0, 0, 9);
            yield return new WaitForSeconds(0.005f);
            countTime++;
        }

        Player.transform.Rotate(0, 0, 90, Space.Self);
        PlayerR.isKinematic = false;
        isCube = true;
        yield return null;
    }


    IEnumerator RR() //우회전
    {
        PlayerR.gravityScale = 1;
        int countTime = 0;
        while (countTime < 10)
        {
            transform.Rotate(0, 0, 9);
            yield return new WaitForSeconds(0.005f);
            countTime++;
        }
        yield return null;
    }
    IEnumerator LR() //좌회전
    {
        PlayerR.gravityScale = 1;
        int countTime = 0;
        while (countTime < 10)
        {
            transform.Rotate(0, 0, -9);
            yield return new WaitForSeconds(0.005f);
            countTime++;
        }
        yield return null;
    }

}