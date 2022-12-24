using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public int[,] area;
    public int player = 1;
    public int rock = 2;
    public int tree = 3;
    public int goal = 4;
    public int X = -1;
    public int height;
    public int width;

    public GameObject[,] areaGameobjects;
    public bool GenerateMap = true;
    float offsetX = -1.0f;
    float offsetY = 0.48f;
    void Start()
    {
        area = new int[height, width];
        areaGameobjects = new GameObject[height, width];
        area[3, 0] = 1;
        if (GenerateMap)
            DrawMap(StageCount.instance.nowstage);
    }

    public void DrawMap(int stage)
    {
        string stagename = "_" + stage;
        gameObject.SendMessage(stagename);
        GameObject stone1 = Resources.Load("stone1") as GameObject;
        GameObject stone2 = Resources.Load("stone2") as GameObject;
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (area[i, j] == player)
                {
                    GameObject player = Resources.Load("player") as GameObject;
                    player = Instantiate(player, new Vector3(offsetX + j * .16f, offsetY - i * .16f, 0), Quaternion.identity);
                    areaGameobjects[i, j] = player;
                }
                if (area[i, j] == rock)
                {
                    int random = Random.Range(1, 3);
                    if (random == 1)
                    {
                        GameObject stone = Instantiate(stone1);
                        stone.transform.position = new Vector3(offsetX + j * .16f, offsetY - i * .16f, 0);
                        areaGameobjects[i, j] = stone;
                    }
                    else
                    {
                        GameObject stone = Instantiate(stone2);
                        stone.transform.position = new Vector3(offsetX + j * .16f, offsetY - i * .16f, 0);
                        areaGameobjects[i, j] = stone;
                    }
                }
                if (area[i, j] == tree)
                {
                    area[i, j + 1] = X;
                    if (i + 1 < height)
                    {
                        area[i + 1, j] = X;
                        area[i + 1, j + 1] = X;
                    }
                    if (i + 2 < height)
                    {
                        area[i + 2, j] = X;
                        area[i + 2, j + 1] = X;
                    }
                    GameObject tree = Resources.Load("tree") as GameObject;
                    tree = Instantiate(tree, new Vector3(offsetX + j * .16f, offsetY - i * .16f, 0), Quaternion.identity);
                }
            }
        }
    }

    public int[,] GetMap()
    {
        return area;
    }

    public GameObject[,] GetMapGameobjects()
    {
        return areaGameobjects;
    }
    void _1()
    {
        MoveCount.instance.movecount = 15;
        area[0, 0] = rock;area[6, 1] = rock;area[2, 3] = rock;area[0, 5] = tree;area[5, 6] = rock;area[4, 6] = rock;area[6, 7] = rock;area[3, 7] = rock;area[4, 8] = tree;area[3, 11] = rock;area[0, 11] = rock;area[6, 12] = rock;
    }

    void _2()
    {
        MoveCount.instance.movecount = 22;
        area[0, 0] = rock;area[6, 1] = rock;area[2, 3] = rock;area[0, 5] = tree;area[5, 6] = rock;area[4, 6] = rock;area[6, 7] = rock;area[3, 7] = rock;area[4, 8] = tree;area[3, 8] = rock;area[3, 11] = rock;area[0, 11] = rock;area[6, 12] = rock;
    }

    void _3()
    {
        MoveCount.instance.movecount = 23;
        area[0, 0] = rock;area[4, 2] = tree;area[2, 3] = rock;area[6, 4] = rock;area[5, 4] = rock;area[3, 4] = rock;area[4, 5] = rock;area[0, 5] = tree;area[5, 6] = rock;area[4, 6] = rock;area[3, 6] = rock;area[3, 7] = rock;area[0, 7] = rock;area[5, 8] = tree;area[5, 10] = rock;area[2, 10] = rock;area[6, 13] = rock;
    }

    void _4()
    {
        MoveCount.instance.movecount = 28;
        area[0, 0] = rock; area[6, 13] = rock; area[0, 5] = rock; area[0, 7] = rock; area[0, 8] = rock; area[0, 11] = rock; area[0, 13] = rock; area[1, 0] = rock; area[1, 3] = rock; area[1, 4] = rock; area[1, 6] = rock; area[1, 8] = rock; area[1, 11] = rock; area[2, 0] = rock; area[2, 1] = rock; area[2, 2] = rock; area[2, 6] = rock; area[2, 8] = rock; area[2, 10] = rock; area[2, 11] = rock; area[2, 13] = rock; area[3, 2] = rock; area[3, 3] = rock; area[3, 4] = rock; area[3, 5] = rock; area[3, 7] = rock; area[3, 8] = rock; area[3, 9] = rock; area[3, 10] =rock; area[3, 13] = rock; area[4, 0] = rock; area[4, 3] = rock; area[4, 4] = rock; area[4, 5] = rock; area[4, 6] = rock; area[4, 7] = rock; area[4, 9] = rock; area[4, 10] = rock; area[5, 2] = rock; area[5, 12] = rock; area[5, 13] = rock; area[6, 0] = rock; area[6, 2] = rock; area[6, 3] = rock; area[6, 4] = rock; area[6, 7] = rock; area[6, 8] = rock; area[6, 9] =rock; area[6, 12] = rock; area[6, 13] = rock;
    }

    void _5()
    {
        MoveCount.instance.movecount = 30;
        area[0, 0] = rock;area[6, 13] = rock;area[0, 5] = tree;area[0, 7] = rock;area[0, 8] = rock;area[0, 11] = rock;area[0, 13] = rock;area[1, 0] = rock;area[1, 3] = rock;area[1, 4] = rock;area[1, 8] = rock;area[1, 11] = rock;area[2, 0] = rock;area[2, 1] = rock;area[2, 2] = rock;area[2, 8] = rock;area[2, 10] = rock;area[2, 11] = rock;area[2, 13] = rock;area[3, 2] = rock;area[3, 3] = rock;area[3, 5] = rock;area[3, 7] = rock;area[3, 8] = rock;area[3, 10] = rock;area[3, 13] = rock;area[4, 4] = rock;area[4, 5] = rock;area[4, 6] = rock;area[4, 7] = rock;area[4, 9] = rock;area[4, 10] = rock;area[5, 1] = rock;area[5, 2] = rock;area[5, 3] = rock;area[5, 8] = rock;area[5, 12] = rock;area[5, 13] = rock;area[6, 0] = rock;area[6, 2] = rock;area[6, 3] = rock;area[6, 4] = rock;area[6, 7] = rock;area[6, 8] = rock;area[6, 9] = rock;area[6, 12] = rock;area[6, 13] = rock;area[3, 0] = player;
    }

    void _6()
    {
        MoveCount.instance.movecount = 23;
        area[0, 0] = rock; area[6, 13] = rock; area[0, 0] = rock; area[0, 1] = rock; area[0, 3] = rock; area[0, 4] = rock; area[0, 8] = rock; area[0, 9] = rock; area[0, 13] = rock; area[1, 0] = rock; area[1, 1] = rock; area[1, 3] = rock; area[1, 4] = rock; area[1, 6] = rock; area[1, 9] = rock; area[1, 11] = rock; area[1, 13] = rock; area[2, 0] = rock; area[2, 1] = rock; area[2, 3] = rock; area[2, 7] = rock; area[2, 9] = rock; area[2, 13] = rock; area[3, 2] = rock; area[3, 5] = tree; area[4, 0] = rock; area[4, 1] = rock; area[4, 4] = rock; area[4, 7] = rock; area[4, 11] = rock; area[4, 12] = rock; area[5, 0] = rock; area[5, 1] = rock; area[5, 2] = rock; area[5, 3] = rock; area[5, 8] = rock; area[5, 10] = rock; area[6, 0] = rock; area[6, 3] = rock; area[6, 4] = rock; area[6, 5] = rock; area[6, 6] = rock; area[6, 8] = rock; area[6, 9] = rock; area[6, 11] = rock; area[6, 13] = rock; area[3, 0] = player;
    }
    void _7()
    {
        MoveCount.instance.movecount = 22;
        area[0, 0] = rock; area[6, 13] = rock; area[0, 0] = rock; area[0, 2] = rock; area[0, 6] = rock; area[0, 7] = rock; area[0, 10] = rock; area[0, 11] = tree; area[0, 13] = rock; area[1, 5] = rock; area[1, 6] = rock; area[1, 7] = rock; area[1, 8] = rock; area[1, 13] = rock; area[2, 2] = rock; area[2, 3] = rock; area[2, 6] = rock; area[3, 1] = rock; area[3, 2] = rock; area[3, 3] = rock; area[3, 4] = rock; area[3, 7] = rock; area[3, 9] = rock; area[4, 0] = rock; area[4, 6] = rock; area[4, 7] = rock; area[4, 11] = rock; area[4, 12] = rock; area[4,13] = rock; area[5, 0] = rock; area[5, 3] = rock; area[5, 5] = rock; area[5, 6] = rock; area[5, 7] = rock; area[5, 10] = rock; area[6, 0] = rock; area[6, 1] = rock; area[6, 2] = rock; area[6, 4] = rock; area[6, 5] = rock; area[6, 7] = rock; area[6, 10] = rock; area[6, 11] = rock; area[6, 13] = rock; area[3, 0] = player;
    }
    
    void _8()
    {
        MoveCount.instance.movecount = 33;
        area[6, 0] = 2; area[4, 0] = 2; area[2, 0] = 2; area[4, 1] = 2; area[3, 1] = 2; area[1, 1] = 2; area[5, 2] = 2; area[3, 2] = 2; area[2, 2] = 2; area[1, 2] = 2; area[0, 2] = 2; area[6, 3] = 2; area[5, 4] = 2; area[4, 4] = 2; area[2, 4] = 2; area[1, 4] = 2; area[0, 4] = 2; area[6, 5] = 2; area[4, 5] = 2; area[0, 5] = 3; area[5, 6] = 2; area[3, 6] = 2; area[4, 7] = 2; area[1, 7] = 2; area[6, 8] = 2; area[5, 8] = 2; area[2, 8] = 2; area[3, 9] = 2; area[0, 9] = 2; area[5, 10] = 2; area[4, 10] = 2; area[1, 10] = 2; area[5, 11] = 2; area[1, 11] = 2; area[6, 12] = 2; area[4, 12] = 2; area[3, 12] = 2; area[2, 12] = 2; area[1, 12] = 2; area[0, 12] = 2; area[6, 13] = 2; area[5, 13] = 2; area[4, 13] = 2; area[0, 13] = 2;
    }

    void _9()
    {
        MoveCount.instance.movecount = 30;
        area[6, 0] = 2; area[0, 0] = 2; area[2, 1] = 2; area[4, 2] = 2; area[5, 3] = 2; area[3, 3] = 2; area[0, 3] = 3; area[4, 4] = 2; area[6, 5] = 2; area[5, 5] = 2; area[4, 5] = 2; area[3, 5] = 2; area[2, 6] = 2; area[5, 7] = 2; area[3, 7] = 2; area[1, 7] = 2; area[6, 8] = 2; area[4, 8] = 2; area[2, 8] = 2; area[5, 9] = 2; area[2, 9] = 2; area[1, 9] = 2; area[0, 9] = 2; area[6, 10] = 2; area[4, 10] = 2; area[2, 10] = 2; area[5, 11] = 2; area[3, 11] = 2; area[2, 11] = 2; area[4, 12] = 2; area[2, 12] = 2; area[0, 12] = 2; area[6, 13] = 2; area[5, 13] = 2; area[3, 13] = 2;
    }
    void _10()
    {
        MoveCount.instance.movecount = 29;
        area[0, 0] = rock; area[0, 0] = rock; area[0, 2] = rock; area[0, 3] = rock; area[0, 5] = rock; area[0, 7] = rock; area[0, 12] = rock; area[0, 13] = rock; area[1, 3] = rock; area[1, 5] = rock; area[1, 7] = rock; area[1, 8] = rock; area[1, 12] = rock; area[2, 1] = rock; area[2, 5] = rock; area[2, 8] = rock; area[2, 11] = tree; area[2, 13] = rock; area[3, 1] = tree; area[3, 9] = rock; area[4, 0] = rock; area[4, 3] = rock; area[4, 4] = rock; area[4, 5] = rock; area[4, 7] = rock; area[4, 9] = rock; area[4, 10] = rock; area[4, 13] = rock; area[5, 0] = rock; area[5, 3] = rock; area[5, 5] = rock; area[5, 7] = rock; area[5, 9] = rock; area[5, 12] = rock; area[6, 0] = rock; area[6, 1] = rock; area[6, 2] = rock; area[6, 3] = rock; area[6, 4] = rock; area[6, 5] = rock; area[6, 6] = rock; area[6, 8] = rock; area[6, 11] = rock; area[3, 0] = player;
    }

}
