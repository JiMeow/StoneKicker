using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMovePlayer : MonoBehaviour
{
    public float speed = 1f;
    float startPosX = -0.89f;
    float backPosX = -1.7f;
    GameObject stone;
    bool isAnimation = false;
    bool isgo = true;

    void Start()
    {
        stone = GameObject.Find("stone1");
    }
    
    void Update()
    {
        if (isAnimation)
            return;
        isAnimation = true;

        // turn back;
        if (transform.position.x > 1.30f)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            isgo = false;
            startPosX = -0.89f;
        }
        if (isgo)
            MoveToPos();
        else if (!isgo)
            MoveBackToPos();
    }

    void MoveToPos()
    {
        StartCoroutine(MoveToPosCoroutine());
    }

    // move to startPoxX
    IEnumerator MoveToPosCoroutine()
    {
        while (transform.position.x < startPosX)
        {
            transform.position = new Vector3(transform.position.x + speed * 0.0025f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(0.0025f);
        }
        yield return new WaitForSeconds(1f);
        // if end of screen move back
        if (transform.position.x > 1.30f)
        {
            isAnimation = false;
            yield break;
        }
        PlayerKickStone();
    }
    
    void PlayerKickStone()
    {
        StartCoroutine(PlayerKickStoneCoroutine());
    }

    // do like kick stone and also call stone to move forward
    IEnumerator PlayerKickStoneCoroutine()
    {
        Sound.instance.PlayKickSound();
        for (int i = 0; i < 20; i++)
        {
            transform.position = new Vector3(transform.position.x + speed * .0025f, transform.position.y, 0);
            yield return new WaitForSeconds(0.0025f);
        }
        for (int i = 0; i < 20; i++)
        {
            transform.position = new Vector3(transform.position.x - speed * .0025f, transform.position.y, 0);
            yield return new WaitForSeconds(0.0025f);
        }
        stone.GetComponent<MenuStoneMove>().MoveForward();
        yield return new WaitForSeconds(0.25f);
        startPosX = stone.transform.position.x - 0.19f;
        isAnimation = false;
    }

    void MoveBackToPos()
    {
        StartCoroutine(MoveBackToPosCoroutine());
    }

    // move back to start of screen and a little bit more
    IEnumerator MoveBackToPosCoroutine()
    {
        while (transform.position.x > backPosX)
        {
            transform.position = new Vector3(transform.position.x - speed * 0.0025f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(0.0025f);
        }
        yield return new WaitForSeconds(1f);
        stone.GetComponent<MenuStoneMove>().MoveBack(-0.7f);
        yield return new WaitForSeconds(3f);
        isAnimation = false;
        isgo = true;
        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
}
