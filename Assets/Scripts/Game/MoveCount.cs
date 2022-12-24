using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCount : MonoBehaviour
{
    public static MoveCount instance;
    public int movecount;

    Text moveLeft;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        moveLeft = GameObject.Find("MoveLeft").GetComponent<Text>();
        moveLeft.text = "Move: " + movecount;
    }

    public void DecreaseMove()
    {
        movecount--;
        if(movecount < 0)
        {
            GameManager.instance.RestartStage();
        }
        else
        {
            moveLeft.text = "Move: " + movecount;
        }
    }
    
    public void IncreaseMove()
    {
        movecount++;
    }
}
