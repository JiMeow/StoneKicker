using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    MapManager mapManager;
    int[,] area;
    GameObject[,] areaGameobjects;
    void Start()
    {
        mapManager = GameObject.Find("GameManager").GetComponent<MapManager>();
        area = mapManager.GetMap();
        areaGameobjects = mapManager.GetMapGameobjects();
    }
    
    void Update()
    {
        MovePlayer();
    }
    int[] FindPlayer()
    {
        int[] playerPos = new int[2];
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                if (area[i, j] == mapManager.player)
                {
                    playerPos[0] = i;
                    playerPos[1] = j;
                }
            }
        }
        return playerPos;
    }

    void MovePlayer()
    {
        int[] playerPos = FindPlayer();
        int x = playerPos[0];
        int y = playerPos[1];
        Debug.Log("x:" + x);
        Debug.Log("y:" + y);
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (x >= 1 && area[x - 1, y] == 0)
            {
                area[x, y] = 0;
                area[x - 1, y] = 1;
                
                areaGameobjects[x, y].transform.position = new Vector3(areaGameobjects[x, y].transform.position.x, areaGameobjects[x, y].transform.position.y + .16f, 0);
                areaGameobjects[x - 1, y] = areaGameobjects[x, y];
                areaGameobjects[x, y] = null;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (x < mapManager.height - 1 && area[x + 1, y] == 0)
            {
                area[x, y] = 0;
                area[x + 1, y] = 1;
                
                areaGameobjects[x, y].transform.position = new Vector3(areaGameobjects[x, y].transform.position.x, areaGameobjects[x, y].transform.position.y - .16f, 0);
                areaGameobjects[x + 1, y] = areaGameobjects[x, y];
                areaGameobjects[x, y] = null;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (y >= 1 && area[x, y - 1] == 0)
            {
                area[x, y] = 0;
                area[x, y - 1] = 1;
                
                areaGameobjects[x, y].transform.position = new Vector3(areaGameobjects[x, y].transform.position.x - .16f, areaGameobjects[x, y].transform.position.y, 0);
                areaGameobjects[x, y - 1] = areaGameobjects[x, y];
                areaGameobjects[x, y] = null;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (y < mapManager.width - 1 && area[x, y + 1] == 0)
            {
                area[x, y] = 0;
                area[x, y + 1] = 1;
                
                areaGameobjects[x, y].transform.position = new Vector3(areaGameobjects[x, y].transform.position.x + .16f, areaGameobjects[x, y].transform.position.y, 0);
                areaGameobjects[x, y + 1] = areaGameobjects[x, y];
                areaGameobjects[x, y] = null;
            }
        }
    }
}
