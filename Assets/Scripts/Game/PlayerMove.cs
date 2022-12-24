using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    MapManager mapManager;
    int[,] area;
    GameObject[,] areaGameobjects;
    bool isMoveReady = true;
    void Start()
    {
        mapManager = GameObject.Find("GameController").GetComponent<MapManager>();
        area = mapManager.GetMap();
        areaGameobjects = mapManager.GetMapGameobjects();
    }
    
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if (!isMoveReady)
            return;
        
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
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (NotIndexOutOfRange(playerPos, +1, 0))
            {
                Move(playerPos, +1, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            if (NotIndexOutOfRange(playerPos, 0, -1))
            {
                Move(playerPos, 0, -1);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            if (NotIndexOutOfRange(playerPos, 0, +1))
            {
                Move(playerPos, 0, +1);
            }
        }
    }

    bool isWin()
    {
        int y = FindPlayer()[1];
        if (y >= mapManager.width - 1)
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
            MoveCount.instance.DecreaseMove();
            if (MoveCount.instance.movecount < 0)
                return;

            area[x, y] = 0;
            area[x + directx, y + directy] = 1;
            //areaGameobjects[x, y].transform.position = new Vector3(areaGameobjects[x, y].transform.position.x + directy * .16f, areaGameobjects[x, y].transform.position.y - directx * .16f, 0);
            areaGameobjects[x + directx, y + directy] = areaGameobjects[x, y];
            areaGameobjects[x, y] = null;
            
            StartCoroutine(MoveAnimation(areaGameobjects[x + directx, y + directy], directx, directy));
            if (isWin())
                GameManager.instance.LoadNextStage();
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
            
            MoveCount.instance.DecreaseMove();
            if (MoveCount.instance.movecount < 0)
                return;

            area[x + directx, y + directy] = 0;
            area[x + directx * 2, y + directy * 2] = 2;
            //areaGameobjects[x + directx, y + directy].transform.position = new Vector3(areaGameobjects[x+directx, y+directy].transform.position.x + directy * .16f, areaGameobjects[x + directx, y + directy].transform.position.y - directx * .16f, 0);
            areaGameobjects[x + directx * 2, y + directy * 2] = areaGameobjects[x + directx, y + directy];
            areaGameobjects[x + directx, y + directy] = null;
            
            StartCoroutine(PlayerHitAnimation(areaGameobjects[x, y], directx, directy));
            StartCoroutine(MoveAnimation(areaGameobjects[x + directx * 2, y + directy * 2], directx, directy));
        }
    }

    IEnumerator MoveAnimation(GameObject game, int directx, int directy)
    {
        isMoveReady = false;
        for (int i = 0; i < 20; i++)
        {
            game.transform.position = new Vector3(game.transform.position.x + directy * .008f, game.transform.position.y - directx * .008f, 0);
            yield return new WaitForSeconds(0.005f);
        }
        isMoveReady = true;
    }

    IEnumerator PlayerHitAnimation(GameObject game, int directx, int directy)
    {
        for (int i = 0; i < 20; i++)
        {
            game.transform.position = new Vector3(game.transform.position.x + directy * .0025f, game.transform.position.y - directx * .0025f, 0);
            yield return new WaitForSeconds(0.0025f);
        }
        for (int i = 0; i < 20; i++)
        {
            game.transform.position = new Vector3(game.transform.position.x - directy * .0025f, game.transform.position.y + directx * .0025f, 0);
            yield return new WaitForSeconds(0.0025f);
        }
    }

    int[] FindPlayer()
    {
        int[] playerPos = new int[2];
        for (int i = 0; i < mapManager.height; i++)
        {
            for (int j = 0; j < mapManager.width; j++)
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
}
