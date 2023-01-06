using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileKeyRight : MonoBehaviour
{
    private void OnMouseDown()
    {
        KeyBoardInputPlayerMove.instance.moveRight = true;
    }
}
