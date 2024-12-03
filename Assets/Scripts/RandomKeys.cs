using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomKeys : MonoBehaviour
{
    
    public Transform parentObject;

    
    public Vector2 positionRangeMin = new Vector2(-5, -5);
    public Vector2 positionRangeMax = new Vector2(5, 5);

    void Start()
    {
        
        RandomizeAllPositions();
    }

    void RandomizeAllPositions()
    {
        
        List<Transform> children = new List<Transform>();

        
        foreach (Transform child in parentObject)
        {
            
            children.Add(child);
        }

        
        foreach (Transform child in children)
        {
            
            float randomX = Random.Range(positionRangeMin.x, positionRangeMax.x);
            float randomY = Random.Range(positionRangeMin.y, positionRangeMax.y);

            
            child.position = new Vector3(randomX, randomY, child.position.z);
        }
    }
}
