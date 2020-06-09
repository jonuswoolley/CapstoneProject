using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //public Animator Player;
    public Canvas PlayerCanvas;
    public Camera PlayerCam;
    public GameObject MainMenuCam;

    public LoadOnStart loadData;
    public GameObject EnemySpawn;
    public GameObject BeforeBoss;

    public GameObject PlayButton;
    public GameObject StartNewButton;
    public GameObject ResumeButton;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        RenderSettings.fog = false;
    }

    public void Resume()
    {
        Time.timeScale = 1;

        //MainMenuCam.tag = ";
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        RenderSettings.fog = true;

        PlayerCanvas.enabled = true;
        PlayerCam.enabled = true;

        MainMenuCam.SetActive(false);
        gameObject.SetActive(false);
    }

    public void StartNew()
    {
        EnemySpawn.SetActive(false);
        BeforeBoss.SetActive(false);

        //MainMenuCam.tag = "Untagged";
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        RenderSettings.fog = true;

        PlayerCanvas.enabled = true;
        PlayerCam.enabled = true;

        PlayButton.SetActive(false);
        StartNewButton.SetActive(false);
        ResumeButton.SetActive(true);

        SaveAndLoad.Save();

        gameObject.SetActive(false);
    }

    public void Play()
    {
        loadData.LoadData();

        //MainMenuCam.tag = "Untagged";
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        RenderSettings.fog = true;

        PlayerCanvas.enabled = true;
        PlayerCam.enabled = true;

        PlayButton.SetActive(false);
        StartNewButton.SetActive(false);
        ResumeButton.SetActive(true);

        gameObject.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
