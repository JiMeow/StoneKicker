using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardInputPlayerMove : MonoBehaviour
{
    public static KeyBoardInputPlayerMove instance;
    public bool moveUp = false;
    public bool moveDown = false;
    public bool moveLeft = false;
    public bool moveRight = false;
    
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
