using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
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

    Image fadeImage;
    MapManager map;

    private void Start()
    {
        fadeImage = GameObject.Find("Bg").GetComponent<Image>();
        map = FindObjectOfType<MapManager>().GetComponent<MapManager>();
        StartCoroutine(Transparent());
    }

    private void Update()
    {
        if (Time.timeScale == 0) 
            return;
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartStage();
        }
    }

    public void RestartStage()
    {
        StageCount.instance.restart += 1;
        Sound.instance.PlayDeadSound();
        Time.timeScale = 0;
        StageCount.instance.nowstage = 1;
        StartCoroutine(BlackPlayer());
        StartCoroutine(OpaqueAndLoadScene());
    }

    public void LoadNextStage()
    {
        Sound.instance.PlayWinSound();
        StageCount.instance.StageUp();
        Time.timeScale = 0;
        StartCoroutine(OpaqueAndLoadScene());
    }

    IEnumerator Transparent()
    {
        if (fadeImage == null)
            yield break;
        Color color = fadeImage.color;
        while (color.a > 0)
        {
            color.a -= 0.01f;
            fadeImage.color = color;
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator OpaqueAndLoadScene()
    {
        Color color = fadeImage.color;
        while (color.a < 1)
        {
            color.a += 0.01f;
            fadeImage.color = color;
            yield return new WaitForSecondsRealtime(0.01f);
        }
        Time.timeScale = 1;
        if (SceneManager.GetActiveScene().name == "Ending")
        {
            StageCount.instance.nowstage = 1;
            SceneManager.LoadScene("Menu");
            yield break;
        }
        if (StageCount.instance.nowstage == map.numberOfStage + 1)
        {
            SceneManager.LoadScene("Ending");
            yield break;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator BlackPlayer()
    {
        GameObject player = GameObject.Find("player(Clone)");
        SpriteRenderer playerSprite = player.GetComponent<SpriteRenderer>();
        Color color = playerSprite.color;
        while (color.r != 0)
        {
            color.r -= 0.01f;
            color.g -= 0.01f;
            color.b -= 0.01f;
            playerSprite.color = color;
            yield return new WaitForSecondsRealtime(0.01f);
        }
    }
}
