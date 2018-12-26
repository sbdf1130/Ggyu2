using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelRotate : MonoBehaviour {

    public void leftRotate()
    {
        StartCoroutine("LR");
    }
    public void rightRotate()
    {
        StartCoroutine("RR");
    }

    IEnumerator RR()
    {
        int countTime = 0;
        while (countTime < 10)
        {
            transform.Rotate(0, 0, 9);
            yield return new WaitForSeconds(0.01f);
            countTime++;
        }
        yield return null;
    }
    IEnumerator LR()
    {
        int countTime = 0;
        while (countTime < 10)
        {
            transform.Rotate(0, 0, -9);
            yield return new WaitForSeconds(0.01f);
            countTime++;
        }
        yield return null;
    }
}
