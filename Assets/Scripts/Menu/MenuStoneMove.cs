using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStoneMove : MonoBehaviour
{
    public float speed = 1.0f;

    public void MoveForward()
    {
        StartCoroutine(MoveForwardCoroutine());
    }

    IEnumerator MoveForwardCoroutine()
    {
        for (int i = 0; i < 20; i++)
        {
            transform.position = new Vector3(transform.position.x + speed * .008f, transform.position.y, 0);
            yield return new WaitForSeconds(0.005f);
        }
    }

    public void MoveBack(float target)
    {
        StartCoroutine(MoveBackCoroutine(target));
    }

    IEnumerator MoveBackCoroutine(float target)
    {
        while (transform.position.x > target) { 
            transform.position = new Vector3(transform.position.x - speed * .008f, transform.position.y, 0);
            yield return new WaitForSeconds(0.005f);
        }
    }
}
