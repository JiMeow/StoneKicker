using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
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
        mapManager.DrawMap(StageCount.instance.nowstage);
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
                    if (tile.name == "tileset_grassland_8")
                    {
                        area[mapManager.height - y - 1, x] = mapManager.rock;
                        s += "area[" + (mapManager.height - y - 1) + "," + x + "] = " + mapManager.rock + ";\n";
                    }
                    else if(tile.name == "tileset_grassland_29")
                    {
                        area[mapManager.height - y - 1, x] = mapManager.tree;
                        s += "area[" + (mapManager.height - y - 1) + "," + x + "] = " + mapManager.tree + ";\n";
                    }
                    //else Debug.Log(tile.name);
                }
            }
        }
        Debug.Log(s);
    }
}
