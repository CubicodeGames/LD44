using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsController : MonoBehaviour
{
    public static ControlsController Instance = null;

    public Canvas aboutCanvas;
    public Canvas controlsCanvas;
    
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        if (Instance != this)
        {
            Destroy(gameObject);
        }

        aboutCanvas.gameObject.SetActive(true);
        controlsCanvas.gameObject.SetActive(false);
    }

    public void ShowControls()
    {
        aboutCanvas.gameObject.SetActive(false);
        controlsCanvas.gameObject.SetActive(true);
    }

    public void HideControls()
    {
        aboutCanvas.gameObject.SetActive(true);
        controlsCanvas.gameObject.SetActive(false);
    }
}
