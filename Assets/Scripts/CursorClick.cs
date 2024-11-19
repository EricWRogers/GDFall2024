using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorClick : MonoBehaviour
{
    public Texture2D cursorNormal;
    public Texture2D cursorHover;
    public Vector2 hotspot = new Vector2(16, 16);
    public float detectionRadius = 2f;

    private GameObject player;
    private bool isPlayerNearby = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

            if (distanceToPlayer <= detectionRadius)
            {
                if(!isPlayerNearby)
                {
                    isPlayerNearby = true;
                    Cursor.SetCursor(cursorHover, hotspot, CursorMode.Auto);
                }
            }
        }
        else
        {
            if (isPlayerNearby)
            {
                isPlayerNearby = false;
                Cursor.SetCursor(cursorNormal, hotspot, CursorMode.Auto);
            }
        }
    }

    // private void OnMouseEnter()
    // {
    //     Cursor.SetCursor(cursorHover, hotspot, CursorMode.Auto)
    // }

    // private void OnMouseExit()
    // {
    //     Cursor.SetCursor(cursorNormal, hotspot, CursorMode.Auto);
    // }
}
