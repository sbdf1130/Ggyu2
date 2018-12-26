using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {

    private Vector2 startTP, endTP;
    GameObject Wheel;
    GameObject Light;
    Rigidbody2D rgdy;
    public int dir;
    public Animator ani;
    public Sprite[] sp;

    void Awake()
    {
        dir = 0;
        ani = GetComponent<Animator>();
        rgdy = GetComponent<Rigidbody2D>();
        Wheel = GameObject.Find("Wheel");
        Light = GameObject.Find("Light");
    }

    void Update()
    {
        if (dir == 0) // 하
        {
            Physics2D.gravity = new Vector2(0f, -20f);
            rgdy.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
        else if (dir == 1) // 좌
        {
            Physics2D.gravity = new Vector2(-20f, 0f);
            rgdy.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
        else if (dir == 2) // 상
        {
            Physics2D.gravity = new Vector2(0f, 20f);
            rgdy.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
        else if (dir == 3) // 우
        {
            Physics2D.gravity = new Vector2(20f, 0f);
            rgdy.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
        else if (dir == 4)
        {
            dir = 0;
        }
        else if (dir == -1)
        {
            dir = 3;
        }

        ///////// 스와이프 ////////
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTP = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTP = Input.GetTouch(0).position;
            if ((endTP.x - startTP.x > 100f) && rgdy.velocity.x ==0&& rgdy.velocity.y == 0)
            {
                left();
            }
            if (startTP.x - endTP.x > 100f && rgdy.velocity.x == 0 && rgdy.velocity.y == 0)
            {
                right();
            }
        }
    }

    void left()
    {
        rgdy.gravityScale = 1;
        Wheel.GetComponent<wheelRotate>().leftRotate();
        //Light.GetComponent<LightRotate>().leftRotate();
        //transform.Rotate(0, 0, -90);
        ani.enabled = true;
        StartCoroutine("leftRot");
    }
    void right()
    {
        rgdy.gravityScale = 1;
        Wheel.GetComponent<wheelRotate>().rightRotate();
        //Light.GetComponent<LightRotate>().rightRotate();
        //transform.Rotate(0, 0, 90);
        ani.enabled = true;
        StartCoroutine("rightRot");
    }
    IEnumerator leftRot()
    {
        rgdy.isKinematic = true;
        int countTime = 0;
        while (countTime < 10)
        {
            transform.Rotate(0, 0, -9);
            yield return new WaitForSeconds(0.01f);
            countTime++;
        }
        dir++;
        rgdy.isKinematic = false;
        yield return null;
    }
    IEnumerator rightRot()
    {
        rgdy.isKinematic = true;
        int countTime = 0;
        while (countTime < 10)
        {
            transform.Rotate(0, 0, 9);
            yield return new WaitForSeconds(0.01f);
            countTime++;
        }
        dir--;
        rgdy.isKinematic = false;
        yield return null;
    }
}
