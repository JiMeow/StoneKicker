using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public int[,] area;
    public int player = 1;
    public int rock = 2;
    public int height = 7;
    public int width = 13;

    public GameObject[,] areaGameobjects;
    float offsetX = -1.0f;
    float offsetY = 0.48f;
    void Start()
    {
        area = new int[height, width];
        areaGameobjects = new GameObject[height, width];
        area[3, 0] = 1;
        area[0, 1] = 2;
        area[0, 2] = 2;
        DrawMap();
    }

    void DrawMap()
    {
        GameObject stone1 = Resources.Load("stone1") as GameObject;
        GameObject stone2 = Resources.Load("stone2") as GameObject;
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (area[i,j] == player)
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
}
