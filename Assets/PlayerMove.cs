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
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (NotIndexOutOfRange(playerPos, -1, 0))
            {
                Move(playerPos,-1, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (NotIndexOutOfRange(playerPos, +1, 0))
            {
                Move(playerPos, +1, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (NotIndexOutOfRange(playerPos, 0, -1))
            {
                Move(playerPos, 0, -1);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (NotIndexOutOfRange(playerPos, 0, +1))
            {
                Move(playerPos, 0, +1);
            }
        }
    }

    bool NotIndexOutOfRange(int[] playerPos, int directx, int directy)
    {
        int x = playerPos[0];
        int y = playerPos[1];
        if (x + directx >= 0 && x + directx < mapManager.height && y + directy >= 0 && y + directy < mapManager.width)
        {
            return true;
        }
        return false;
    }

    void Move(int[] playerPos, int directx,int directy)
    {
        int x = playerPos[0];
        int y = playerPos[1];
        if (area[x + directx, y + directy] == 0)
        {
            area[x, y] = 0;
            area[x + directx, y + directy] = 1;
            //areaGameobjects[x, y].transform.position = new Vector3(areaGameobjects[x, y].transform.position.x + directy * .16f, areaGameobjects[x, y].transform.position.y - directx * .16f, 0);
            areaGameobjects[x + directx, y + directy] = areaGameobjects[x, y];
            areaGameobjects[x, y] = null;
            StartCoroutine(MoveAnimation(areaGameobjects[x + directx, y + directy], directx, directy));
        }
        else if (area[x + directx, y + directy] == mapManager.rock )
        {
            if (!NotIndexOutOfRange(playerPos, directx*2, directy*2))
            {
                return;
            }
            if (area[x + directx * 2, y + directy * 2] != 0)
            {
                return;
            }
            area[x + directx, y + directy] = 0;
            area[x + directx * 2, y + directy * 2] = 2;
            //areaGameobjects[x + directx, y + directy].transform.position = new Vector3(areaGameobjects[x+directx, y+directy].transform.position.x + directy * .16f, areaGameobjects[x + directx, y + directy].transform.position.y - directx * .16f, 0);
            areaGameobjects[x + directx * 2, y + directy * 2] = areaGameobjects[x + directx, y + directy];
            areaGameobjects[x + directx, y + directy] = null;
            StartCoroutine(MoveAnimation(areaGameobjects[x + directx * 2, y + directy * 2], directx, directy));
        }
    }

    IEnumerator MoveAnimation(GameObject game, int directx, int directy)
    {
        for (int i = 0; i < 20; i++)
        {
            game.transform.position = new Vector3(game.transform.position.x + directy * .008f, game.transform.position.y - directx * .008f, 0);
            yield return new WaitForSeconds(0.005f);
        }
    }
}
