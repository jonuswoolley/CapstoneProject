using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit_Health : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 3f;
    public int attackDamage = 40;
    public LayerMask playerLayer;

    private float timestamp;
    public float timeBetweenHits = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timestamp)
        {
            Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, playerLayer);

            foreach (Collider player in hitPlayer)
            {
                if (player.CompareTag("Player"))
                player.GetComponent<PlayerHit_Health>().TakeDamage(attackDamage);
            }
            timestamp = Time.time + timeBetweenHits;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    //Enemy Health ---------------------------------------------------

    public int maxHealth = 100;

    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        StartCoroutine(HurtColor(0.2f));

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }  
    }

    IEnumerator HurtColor(float time)
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(time);
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
}
