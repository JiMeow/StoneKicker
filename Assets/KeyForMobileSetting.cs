using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyForMobileSetting : MonoBehaviour
{
    public bool show = false;
    Image stonePic;
    void Start()
    {
        show = ShowKeyBoard.instance.show;
        stonePic = GetComponent<Image>();
    }
    
    public void on()
    {
        stonePic.color = new Color(1, 1, 1, 1);
    }

    public void off()
    {
        stonePic.color = new Color(1, 1, 1, 0.25f);
    }

    public void click()
    {
        if (show)
        {
            show = false;
            off();
        }
        else
        {
            show = true;
            on();
        }
        ShowKeyBoard.instance.show = show;
    }
}
