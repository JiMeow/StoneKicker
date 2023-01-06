using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileKeyDown : MonoBehaviour
{
    private void OnMouseDown()
    {
        KeyBoardInputPlayerMove.instance.moveDown = true;
    }
}
