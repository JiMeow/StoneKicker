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

    private void Start()
    {
        fadeImage = GameObject.Find("Bg").GetComponent<Image>();
        StartCoroutine(Transparent());
    }

    public void LoadNextStage()
    {
        // Load next stage
        StageCount.instance.StageUp();
        Time.timeScale = 0;

        StartCoroutine(OpaqueAndLoadScene());
    }

    IEnumerator Transparent()
    {
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
