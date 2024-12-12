using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomKeys : MonoBehaviour
{
    public Transform parentObject;
    public GridManager gridManager;

    void Start()
    {
        RandomizeAllPositions();
    }

    void RandomizeAllPositions()
    {
        List<Transform> children = new List<Transform>();

        // Get all children of the parent object
        foreach (Transform child in parentObject)
        {
            children.Add(child);
        }

        // List to store used grid positions
        HashSet<Vector2Int> usedPositions = new HashSet<Vector2Int>();

        // Randomize positions of each child based on grid
        foreach (Transform child in children)
        {
            Vector2Int randomPos = GetUniqueRandomPosition(usedPositions);

            float xPos = randomPos.x * gridManager.tileSize + gridManager.gridOffsetX;
            float yPos = randomPos.y * gridManager.tileSize + gridManager.gridOffsetY;

            child.position = new Vector3(xPos, yPos, child.position.z);
        }
    }

    // Function to get a unique random position
    Vector2Int GetUniqueRandomPosition(HashSet<Vector2Int> usedPositions)
    {
        Vector2Int randomPos;

        // Continue generating random positions until we find one that's not used
        do
        {
            int randomX = Random.Range(0, gridManager.columns);
            int randomY = Random.Range(0, gridManager.rows);
            randomPos = new Vector2Int(randomX, randomY);
        }
        while (usedPositions.Contains(randomPos));

        // Mark the position as used
        usedPositions.Add(randomPos);

        return randomPos;
    }
}
