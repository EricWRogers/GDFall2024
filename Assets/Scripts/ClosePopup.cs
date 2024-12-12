using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePopup : MonoBehaviour
{
    public GameObject popupImage;
    public GameObject closeButton;

    public void CloseImage()
    {
        if (popupImage != null)
        {
            popupImage.SetActive(false);
        }

        if (closeButton != null)
        {
            closeButton.SetActive(false); // Hide the button
        }
    }
}
