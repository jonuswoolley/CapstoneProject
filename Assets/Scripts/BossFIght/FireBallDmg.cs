using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallDmg : MonoBehaviour
{
    PlayerHit_Health playerScript;
    public int FireballDamage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerScript = collision.gameObject.GetComponent<PlayerHit_Health>();
            if (playerScript != null)
            {
                playerScript.TakeDamage(FireballDamage);
                Destroy(gameObject);
            }
            else
                Debug.Log("Missing Script");
        }
        else if (collision.gameObject.CompareTag("Pillar"))
        {
                Destroy(collision.gameObject);
                Destroy(gameObject);
        }
        else
            Destroy(gameObject);
    }
}
