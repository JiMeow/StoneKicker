using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCount : MonoBehaviour
{
    public static StageCount instance;
    public int nowstage = 1;
    void Awake()
    {
        DontDestroyOnLoad(this);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StageUp()
    {
        nowstage++;
    }
}
