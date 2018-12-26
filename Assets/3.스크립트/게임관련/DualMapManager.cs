using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualMapManager : MonoBehaviour
{

    bool swit = true;

    public GameObject Parent;
    public GameObject TilemapA;
    public GameObject TilemapB;
    public GameObject character;

    Rigidbody2D rgdy;
    Collider2D colA;
    Collider2D colB;
    Collider2D colC;

    // Use this for initialization
    void Start()
    {
        rgdy = character.GetComponent<Rigidbody2D>();
        colA = TilemapA.GetComponent<Collider2D>();
        colB = TilemapB.GetComponent<Collider2D>();
        colC = character.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (swit)
        {
            colB.enabled = false;
            colA.enabled = true;
        }
        else
        {
            colB.enabled = true;
            colA.enabled = false;
        }
    }

    public void Click()
    {
        if (swit)
        {
            swit = false;
            StartCoroutine(Rot());
        }
        else
        {
            swit = true;
            StartCoroutine(Rot());
        }
    }
    IEnumerator Rot()
    {
        rgdy.gravityScale = 0;
        colC.enabled = false;
        if (swit)
        {
            for (int i = 0; i < 20; i++)
            {
                Parent.transform.Rotate(0, 4.5f, 0);
                yield return new WaitForSeconds(0.005f);
            }
        }
        if (!swit)
        {
            for (int i = 0; i < 20; i++)
            {
                Parent.transform.Rotate(0, 4.5f, 0);
                yield return new WaitForSeconds(0.005f);
            }
        }
        rgdy.gravityScale = 1;
        yield return null;
        colC.enabled = true;
    }
}
