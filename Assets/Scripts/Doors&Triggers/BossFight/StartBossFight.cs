using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBossFight : MonoBehaviour
{
    public GameObject HealthContainer;
    public BigBossCast CastScript;

    public GameObject door1;
    public GameObject door2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door1.SetActive(true);
            door2.SetActive(true);
            HealthContainer.SetActive(true);
            CastScript.enabled = true;
        }
    }
}
