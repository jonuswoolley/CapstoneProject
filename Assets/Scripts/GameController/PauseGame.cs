using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Cursor.lockState = CursorLockMode.None;
            //Player.enabled = false;
            PlayerCam.enabled = false;
            PlayerCanvas.enabled = false;

            RenderSettings.fog = false;

            MainMenuCam.SetActive(true);
        }
    }
}
