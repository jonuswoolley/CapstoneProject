using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit_Health : MonoBehaviour
{
    Animator EnemyAnim;
    public Renderer EnemyRend;
    public Material EnemyMat;

    public Transform attackPoint;
    public float attackRange = 3f;
    public int attackDamage = 40;
    public LayerMask playerLayer;

    private float timestamp;
    public float timeBetweenHits;
    public float timeBeforeHits;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timestamp)
        {
            Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, playerLayer);
            timestamp = Time.time + timeBeforeHits;
            foreach (Collider player in hitPlayer)
            {
                EnemyAnim.SetTrigger("SlashTrigger");
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
        EnemyAnim = gameObject.GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        StartCoroutine(HurtColor(0.2f, 0.3f));

        if (currentHealth <= 0)
        {
            StartCoroutine(Die(0.3f));
        }  
    }

    IEnumerator Die(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    IEnumerator HurtColor(float flashTime, float dmgTime)
    {
        yield return new WaitForSeconds(dmgTime);
        EnemyRend.GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(flashTime);
        EnemyRend.GetComponent<Renderer>().material = EnemyMat;
    }
}
