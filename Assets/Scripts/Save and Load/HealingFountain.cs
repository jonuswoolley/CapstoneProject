using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class HealingFountain : MonoBehaviour
{
    public GameObject savingIcon;

    public GameObject player;
    public PlayerHit_Health heal;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && heal != null)
        {
            heal.Heal();
            SaveGame();
        }
    }
    public void SaveGame()
    {
        SaveAndLoad.Save();
        StartCoroutine(Saving());
        print("Game saved!");
    }

    IEnumerator Saving()
    {
        savingIcon.SetActive(true);
        yield return new WaitForSeconds(5);
        savingIcon.SetActive(false);
    }
}
