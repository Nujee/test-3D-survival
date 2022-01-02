using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    [SerializeField] private int _countWall = 2;
    [SerializeField] private int _mapSize = 10;
    [SerializeField] [Range(0, 100)] private int _smoothFactor;
    [SerializeField] [Range(0, 100)] private int _fillPercent;
    private GameObject _tile;

    private int[,] _map;
    private int _mapHeight;
    private int _mapLength;

    private void Awake()
    {
        _mapHeight = _mapSize;
        _mapLength = _mapSize;

        _tile = GameObject.CreatePrimitive(PrimitiveType.Plane);

        _map = new int[_mapHeight, _mapLength];

        for (int i = 0; i < _mapLength; i++)
        {
            for (int j = 0; j < _mapHeight; j++)
            {
                _map[i, j] = (UnityEngine.Random.Range(0, 100) < _fillPercent) ? 1 : 0;
            }
        }

        for (int i = 0; i < _smoothFactor; i++)
        {
            SmoothMap();
        }

        for (int i = 0; i < _mapLength; i++)
        {
            for (int j = 0; j < _mapHeight; j++)
            {
                if (_map[i, j] == 1)
                {
                    Instantiate(_tile, new Vector3(j * 10, 0, i * 10), Quaternion.identity);
                }
                
            }
        }

    }

    private void SmoothMap()
    {
        for (int x = 0; x < _mapLength; x++)
        {
            for (int y = 0; y < _mapHeight; y++)
            {
                int neighbourCells = GetWallCount(x, y);

                _map[x, y] = (neighbourCells > _countWall) ? 1 : 0;
            }
        }
    }

    private int GetWallCount(int x, int y)
    {
        int wallCount = 0;

        for (int gridX = x - 1; gridX <= x + 1; gridX++)
        {
            for (int gridY = y - 1; gridY <= y + 1; gridY++)
            {
                if (gridX >= 0 && gridX < _mapLength && gridY >= 0 && gridY < _mapHeight)
                {
                    if (gridX != x || gridY != y)
                    {
                        wallCount += +_map[gridX, gridY];
                    }
                }
                else
                {
                    wallCount++;
                }
            }
        }

        return wallCount;
    }
}
