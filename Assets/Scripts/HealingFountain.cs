﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            
            heal.Heal();
        }
    }
}
