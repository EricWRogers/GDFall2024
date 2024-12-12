using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickImagePopup : MonoBehaviour
{
    public GameObject popupImage;

    void OnMouseDown()
    {
        if (popupImage != null)
        {
            popupImage.SetActive(true);
        }
    }
}
