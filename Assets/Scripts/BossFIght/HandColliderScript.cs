using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandColliderScript : MonoBehaviour
{
    PlayerHit_Health playerScript;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerScript = collision.gameObject.GetComponent<PlayerHit_Health>();
            if (playerScript != null)
            {
                playerScript.TakeDamage(10);
            }
            else
                Debug.Log("Missing Script");
        }
    }
}

