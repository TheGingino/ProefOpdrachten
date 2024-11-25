using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapTool : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile[] tiles;

    public int width = 20;
    public int height = 20;

    public float noiseScale = 10f;


    private void Start()
    {
        GenerateLevel();
    }

    public void GenerateLevel()
    {
        tilemap.ClearAllTiles();

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float noiseValue = Mathf.PerlinNoise(x / noiseScale, y / noiseScale);
                int tileIndex = Mathf.FloorToInt(noiseValue * tiles.Length);
                tilemap.SetTile(new Vector3Int(x, y, 0), tiles[tileIndex]);
            }
        }
    }
}