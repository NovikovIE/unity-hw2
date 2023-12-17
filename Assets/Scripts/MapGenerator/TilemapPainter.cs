using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapPainter : MonoBehaviour
{
    public Tile wallTile;
    public Tilemap tilemap;

    public void PaintMap(int[,] map)
    {
        int width = map.GetLength(0);
        int height = map.GetLength(1);
        CenterTilemap(width, height);
        tilemap.ClearAllTiles();
        for (int x = 0; x < map.GetLength(0); x++)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                if (map[x, y] == 1)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), wallTile);
                }
            }
        }
    }

    public void CenterTilemap(int width, int height)
    {
        tilemap.GetComponent<Transform>().position = new Vector3(-width / 2, -height / 2, 0);
    }

    public void ClearMap()
    {
        tilemap.ClearAllTiles();
    }




}
