using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageCount : MonoBehaviour
{
    public static StageCount instance;
    public int nowstage = 1;
    public int restart = 0;
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

    private void Update()
    {
        TryToSetStageNumber();
    }

    public void StageUp()
    {
        nowstage++;
    }

    void TryToSetStageNumber()
    {
        GameObject stageNumber = GameObject.Find("StageNumber");
        if (stageNumber != null)
        {
            stageNumber.GetComponent<Text>().text = "Stage: " + nowstage;
        }
    }
}
