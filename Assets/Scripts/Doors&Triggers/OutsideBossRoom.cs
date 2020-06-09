using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideBossRoom : MonoBehaviour
{
    public GameObject BeforeBossRoomBool;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            BeforeBossRoomBool.SetActive(true);
    }
}
