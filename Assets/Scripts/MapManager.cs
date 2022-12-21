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
        area[0, 0] = 2;
        area[6, 1] = 2;
        area[2, 3] = 2;
        area[0, 5] = 3;
        area[5, 6] = 2;
        area[4, 6] = 2;
        area[6, 7] = 2;
        area[3, 7] = 2;
        area[4, 8] = 3;
        area[3, 11] = 2;
        area[0, 11] = 2;
        area[6, 12] = 2;
    }

    void _2()
    {
        area[0, 0] = 2;
        area[6, 1] = 2;
        area[2, 3] = 2;
        area[0, 5] = 3;
        area[5, 6] = 2;
        area[4, 6] = 2;
        area[6, 7] = 2;
        area[3, 7] = 2;
        area[4, 8] = 3;
        area[3, 8] = 2;
        area[3, 11] = 2;
        area[0, 11] = 2;
        area[6, 12] = 2;
    }

    void _3()
    {
        area[0, 0] = 2;
        area[4, 2] = 3;
        area[2, 3] = 2;
        area[6, 4] = 2;
        area[5, 4] = 2;
        area[3, 4] = 2;
        area[4, 5] = 2;
        area[0, 5] = 3;
        area[5, 6] = 2;
        area[4, 6] = 2;
        area[3, 6] = 2;
        area[3, 7] = 2;
        area[0, 7] = 2;
        area[5, 8] = 3;
        area[5, 10] = 2;
        area[2, 10] = 2;
        area[6, 13] = 2;
    }
}
