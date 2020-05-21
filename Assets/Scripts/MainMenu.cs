using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    //public Animator Player;

    public Canvas PlayerCanvas;
    public Camera PlayerCam;

    private void Start()
    {
        RenderSettings.fog = false;
    }

    public void Play()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(false);

        RenderSettings.fog = true;

        //Player.enabled = true;
        PlayerCanvas.enabled = true;
        PlayerCam.enabled = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
