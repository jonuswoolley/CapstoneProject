using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class HealingFountain : MonoBehaviour
{
    GameObject player;
    PlayerHit_Health heal;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        heal = player.GetComponent<PlayerHit_Health>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SaveGame();
            heal.Heal(); 
        }
    }
    public void SaveGame()
    {
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
        print("Game saved!");
    }
}
