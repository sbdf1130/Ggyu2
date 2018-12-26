using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotate : MonoBehaviour {

    GameObject Player;
    PlayerRotation PR;
    private void Start()
    {
        Player = GameObject.Find("Player");
        PR = Player.GetComponent<PlayerRotation>();
    }

    private void Update()
    {
        if (PR.dir == 0)
        {
            transform.position = new Vector3(0f, -6.76f, 0);
            transform.rotation = Quaternion.Euler(0, 0, 180f);
        }
        else if (PR.dir == 1)
        {
            transform.position = new Vector3(-6.75f, -0.07f, 0);
            transform.rotation = Quaternion.Euler(0, 0, 90f);
        }
        else if (PR.dir == 2)
        {
            transform.position = new Vector3(0f, 6.65f, 0);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (PR.dir == 3)
        {
            transform.position = new Vector3(6.75f, -0.07f, 0);
            transform.rotation = Quaternion.Euler(0, 0, -90f);
        }
    }
}
