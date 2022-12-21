using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CreateArrayFromTilemap : MonoBehaviour
{
    MapManager mapManager;
    int[,] area;
    void Start()
    {
        mapManager = GameObject.Find("GameManager").GetComponent<MapManager>();
        area = mapManager.GetMap();
        CreateMap();
        mapManager.DrawMap();
    }

    void CreateMap()
    {
        string s = "";
        Tilemap tilemap = GetComponent<Tilemap>();
        tilemap.CompressBounds();
        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);
        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile != null)
                {
                    area[mapManager.height - y - 1, x] = mapManager.rock;
                    s += "area[" + (mapManager.height - y - 1) + "," + x + "] = " + mapManager.rock + ";\n";
                }
            }
        }
        Debug.Log(s);
    }
}
