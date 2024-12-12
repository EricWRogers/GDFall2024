using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorClick : MonoBehaviour
{
    public Texture2D defaultCursor;
    public Texture2D interactCursor;
    public float interactionDistance = 3f;

    private Camera mainCamera;
    private GameObject currentInteractable;

    void Start()
    {
        mainCamera = Camera.main;
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    }

    void Update()
    {
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null)
        {
            GameObject hoveredObject = hit.collider.gameObject;

            CursorClick cursorClick = hoveredObject.GetComponent<CursorClick>();
            if (cursorClick != null && Vector2.Distance(hoveredObject.transform.position, transform.position) <= interactionDistance)
            {
                if (currentInteractable != hoveredObject)
                {
                    currentInteractable = hoveredObject;
                    Cursor.SetCursor(interactCursor, Vector2.zero, CursorMode.Auto);
                }
            }
            else
            {
                ResetCursor();
            }
        }
        else
        {
            ResetCursor();
        }
    }

    void ResetCursor()
    {
        if (currentInteractable != null)
        {
            currentInteractable = null;
            Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
        }
    }
}
