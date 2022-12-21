using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCount : MonoBehaviour
{
    public static MoveCount instance;
    public int movecount;
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

    public void DecreaseMove()
    {
        movecount--;
        if(movecount < 0)
        {
            GameManager.instance.LoadThisStage();
        }
    }
    
    public void IncreaseMove()
    {
        movecount++;
    }
}
