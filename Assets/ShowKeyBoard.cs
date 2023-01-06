using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowKeyBoard : MonoBehaviour
{
    public static ShowKeyBoard instance;
    public bool show = false;
    
    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(this);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        gameObject.SetActive(true);
    }

    private void Update()
    {
        if (show)
        {
            if (SceneManager.GetActiveScene().name != "Game")
                return;
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void UpdateShow()
    {
        if (show)
        {
            if (SceneManager.GetActiveScene().name != "Game")
                return;
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
