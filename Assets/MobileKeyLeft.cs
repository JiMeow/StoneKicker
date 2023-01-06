using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileKeyLeft : MonoBehaviour
{
    private void OnMouseDown()
    {
        KeyBoardInputPlayerMove.instance.moveLeft = true;
    }
}
