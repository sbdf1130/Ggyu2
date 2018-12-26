using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BtnManager : MonoBehaviour {

    public Rigidbody2D rgdy;

    public GameObject UBtn;
    public GameObject DBtn;
    public GameObject LBtn;
    public GameObject RBtn;
    
    void Awake()
    {
        rgdy = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    public void UpBtn()
    {
        Physics2D.gravity = new Vector2(0f, 20f);
        rgdy.gravityScale = 1;
    }
    public void DownBtn()
    {
        Physics2D.gravity = new Vector2(0f, -20f);
        rgdy.gravityScale = 1;
    }
    public void LeftBtn()
    {
        Physics2D.gravity = new Vector2(-20f, 0f);
        rgdy.gravityScale = 1;
    }
    public void RightBtn()
    {
        Physics2D.gravity = new Vector2(20f, 0f);
        rgdy.gravityScale = 1;
    }

    void DisableBtn()
    {
        DBtn.GetComponent<Button>().interactable = false;
        UBtn.GetComponent<Button>().interactable = false;
        LBtn.GetComponent<Button>().interactable = false;
        RBtn.GetComponent<Button>().interactable = false;
    }


    public void LeftRightOnBtn()
    {
        LBtn.GetComponent<Button>().interactable = true;
        RBtn.GetComponent<Button>().interactable = true;
    }
    public void UpDownOnBtn()
    {
        DBtn.GetComponent<Button>().interactable = true;
        UBtn.GetComponent<Button>().interactable = true;
    }

    void Update()
    {
        if((int)rgdy.velocity.y !=0 || (int)rgdy.velocity.x!=0)
        {
            DisableBtn();
        }
    }

}
