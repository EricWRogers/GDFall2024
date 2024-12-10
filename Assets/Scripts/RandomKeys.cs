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

        // Randomize positions of each child based on grid
        foreach (Transform child in children)
        {
            // Randomly select grid coordinates
            int randomX = Random.Range(0, gridManager.columns); 
            int randomY = Random.Range(0, gridManager.rows); 

            
            float xPos = randomX * gridManager.tileSize + gridManager.gridOffsetX;
            float yPos = randomY * gridManager.tileSize + gridManager.gridOffsetY;

            
            child.position = new Vector3(xPos, yPos, child.position.z);
        }
    }
}
