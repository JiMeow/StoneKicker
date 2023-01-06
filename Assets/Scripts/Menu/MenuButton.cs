using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    private void Start()
    {
        ShowKeyBoard.instance.UpdateShow();
    }

    public void ButtonLoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void ButtonLoadHowtoplay()
    {
        SceneManager.LoadScene("Howtoplay");
    }

    public void ButtonBackToMenu()
    {
        if (StageCount.instance != null)
            StageCount.instance.nowstage = 1;
        SceneManager.LoadScene("Menu");
    }

    public void ButtonLoadSetting()
    {
        SceneManager.LoadScene("Setting");
    }

    public void ButtonLoadCredit()
    {
        Application.OpenURL("https://github.com/JiMeow/StonePuzzle");
    }
}
