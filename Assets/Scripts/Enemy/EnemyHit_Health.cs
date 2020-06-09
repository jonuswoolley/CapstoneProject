using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHit_Health : MonoBehaviour
{
    public PlayerHit_Health playerScript;
    Animator EnemyAnim;
    public bool isBoss = false;
    public bool isSmall = false;
    public bool isBig = false;
    public HealthBarController healthBar;

    public Renderer EnemyRend;
    public Material EnemyMat;

    public Audio AudioScript;

    public Transform attackPoint;
    public float attackRange = 3f;
    public int attackDamage = 5;
    public LayerMask playerLayer;

    private float timestamp;
    public float timeBetweenHits;
    public float timeBeforeDMG;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timestamp)
        {
            Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, playerLayer);
            timestamp = Time.time + timeBeforeDMG;
            foreach (Collider player in hitPlayer)
            {
                EnemyAnim.SetTrigger("SlashTrigger");
                StartCoroutine(Hit(timeBeforeDMG, player));
                //player.gameObject.GetComponent<PlayerHit_Health>().TakeDamage(attackDamage);
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

    IEnumerator Hit(float time, Collider player)
    {
        yield return new WaitForSeconds(time);
        player.gameObject.GetComponent<PlayerHit_Health>().TakeDamage(attackDamage);
        if (isSmall)
            AudioScript.PlayStabSound();
        else if (isBig)
            AudioScript.PlaySmashSound();
        else if (isBoss)
            AudioScript.PlayWizHitSound();
    }

    IEnumerator Die(float time)
    {
        yield return new WaitForSeconds(time);
        if (isBoss == true)
        {
            healthBar.DestroyHealthBar();
            playerScript.Winning = true;
            yield return new WaitForSeconds(0.4f);
            Destroy(gameObject);
        }
        else
        {
            EnemyAnim.SetTrigger("DieTrigger");
            yield return new WaitForSeconds(0.4f);
            gameObject.GetComponent<Enemy_Controller>().turnOff();
            Destroy(gameObject.GetComponent<Enemy_Controller>());
            Destroy(this);
        }
            
    }

    IEnumerator HurtColor(float flashTime, float dmgTime)
    {
        yield return new WaitForSeconds(dmgTime);
        if (isBoss == true)
            healthBar.HealthBarDMG(0.05f);

        EnemyRend.GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(flashTime);
        EnemyRend.GetComponent<Renderer>().material = EnemyMat;
    }
}
