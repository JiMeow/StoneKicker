using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void ButtonLoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void ButtonLoadSetting()
    {
        SceneManager.LoadScene("Game");
    }

    public void ButtonLoadCredit()
    {
        Application.OpenURL("https://github.com/JiMeow/StonePuzzle");
    }
}
