using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemy : MonoBehaviour
{
    EnemyHit_Health enemyDMGScript;
    public PlayerHit_Health PlayerScript;

    private void Start()
    {
        enemyDMGScript = gameObject.GetComponent<EnemyHit_Health>();
    }

    private void LateUpdate()
    {
        if (PlayerScript.currentHealth <= 50)
        {
            enemyDMGScript.attackDamage = 0;
        }
    }
}
