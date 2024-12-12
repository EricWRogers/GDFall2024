using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickImagePopup : MonoBehaviour
{
    public GameObject popupImage;
    public GameObject closeButton;

    void OnMouseDown()
    {
        if (popupImage != null)
        {
            popupImage.SetActive(true);
        }

        if (closeButton != null)
        {
            closeButton.SetActive(true); 
        }
    }
}
