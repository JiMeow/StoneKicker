using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMovePlayer : MonoBehaviour
{
    public float speed = 1f;
    float startPosX = -1;  
    void Start()
    {
        MoveToStartPoint();
    }
    
    void Update()
    {
        
    }

    void MoveToStartPoint()
    {
        // Move the player to the start point
        StartCoroutine(MoveToStartPointCoroutine());
    }

    IEnumerator MoveToStartPointCoroutine()
    {
        // Move the player to the start point
        while (transform.position.x < startPosX)
        {
            transform.position = new Vector3(transform.position.x + speed * 0.0025f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(0.0025f);
        }
    }
}
