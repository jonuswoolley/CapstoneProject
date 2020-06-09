using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public GameObject MainMenuCam;
    //public Animator Player;
    public Camera PlayerCam;
    public Canvas PlayerCanvas;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;

            //MainMenuCam.tag = "MainCamera";

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //Player.enabled = false;
            PlayerCam.enabled = false;
            PlayerCanvas.enabled = false;

            RenderSettings.fog = false;

            MainMenuCam.SetActive(true);
        }
    }
}
