using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileKeyUp : MonoBehaviour
{
    private void OnMouseDown()
    {
        KeyBoardInputPlayerMove.instance.moveUp = true;
    }
}
