using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PressAnyBtn : MonoBehaviour
{
    public Text txtTest;
    bool isHide = true;

    void Update()
    {
        if(isHide)
        {
            Color color = txtTest.color;
            color.a = color.a - Time.deltaTime;

            if(color.a < 0)
            {
                color.a = 0.0f;
                isHide = false;
            }
            txtTest.color = color;
        }
        else
        {
            Color color = txtTest.color;
            color.a = color.a + Time.deltaTime;

            if(color.a > 1)
            {
                color.a = 1.0f;
                isHide = true;
            }
            txtTest.color = color;
        }
        Debug.Log(isHide);
    }

}