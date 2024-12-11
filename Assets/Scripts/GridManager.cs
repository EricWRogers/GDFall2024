using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public float[,] Grid;
    public int columns = 10; 
    public int rows = 10;    
    public float tileSize = 1.0f; 

    // the starting position of the grid
    public float gridOffsetX = 2f; 
    public float gridOffsetY = 3f; 

    void Start()
    {
        // Initialize the grid 
        Grid = new float[columns, rows];

        // Populate the grid with random values and spawn the tiles
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                Grid[i, j] = Random.Range(0.0f, 1.0f);
                SpawnTile(i, j, Grid[i, j]);
            }
        }
    }

    private void SpawnTile(int x, int y, float value)
    {
        
        GameObject g = new GameObject("X: " + x + " Y: " + y);

        
        g.transform.position = new Vector3(x * tileSize + gridOffsetX, y * tileSize + gridOffsetY, 0);

    }
}
