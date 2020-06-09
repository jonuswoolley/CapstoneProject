using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDmg : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            other.GetComponent<PlayerHit_Health>().TakeDamage(999);
    }
}
