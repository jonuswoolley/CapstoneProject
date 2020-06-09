using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Invector.vCharacterController;

public class PlayerHit_Health : MonoBehaviour
{
    public Text text;
    private Animator anim;
    private Rigidbody rigy;

    public MainMenu menu;
    public Camera thirdCam;

    public Renderer PlayerRend;

    public Material empty;
    public Material red;
    public Material green;
    public Material yellow;

    public GameObject bottle1;
    public GameObject bottle2;
    public GameObject bottle3;
    public GameObject bottle4;

    public CanvasGroup DeathImage;
    public CanvasGroup WinImage;
    float m_Timer;

    public Audio AudioScript;

    //public Camera cam;
    public Transform attackPoint;
    public float attackRange = 3f;
    public int attackDamage = 40;
    public LayerMask enemyLayers;

    private bool blocking = false;
    private bool hitAllowed = true;

    private float timestamp;
    public float timeBetweenHits = 0.5f;

    private bool dying = false;
    public bool Winning = false;

    // Update is called once per frame
    void Update()
    {
        if (hitAllowed == true && Time.time >= timestamp && Input.GetMouseButtonDown(0))
        {
            Hit();
        }
        if (Time.time >= timestamp && (Input.GetMouseButtonDown(1)))
        {
            Block();
        }
        if (Time.time >= timestamp && (Input.GetMouseButtonUp(1)))
        {
            BlockUp();
        }

        if (dying == true)
        {
            StartCoroutine(TimeBeforeDie());
        }

        if (Winning == true)
        {
            StartCoroutine(BeatGameScreen());
        }
    }

    IEnumerator TimeBeforeDie()
    {
        yield return new WaitForSeconds(2f);
        m_Timer += Time.deltaTime;

        DeathImage.alpha = m_Timer / 1f;

        if (m_Timer > 1f + 1f)
        {
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator BeatGameScreen()
    {
        yield return new WaitForSeconds(2f);
        m_Timer += Time.deltaTime;

        WinImage.alpha = m_Timer / 1f;

        if (m_Timer > 1f + 1f)
        {
            SceneManager.LoadScene(0);
        }
    }

    void Block()
    {
        rigy.constraints = RigidbodyConstraints.FreezePosition;
        rigy.constraints = ~RigidbodyConstraints.FreezePositionY;
        anim.SetBool("DoBlock", true);
        blocking = true;
        hitAllowed = false;
    }

    void BlockUp()
    {
        rigy.constraints = ~RigidbodyConstraints.FreezePosition;
        anim.SetBool("DoBlock", false);
        blocking = false;
        hitAllowed = true;
    }

    void Hit()
    {
        anim.SetTrigger("AttackTrigger");
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider enemy in hitEnemies)
        {
            if (enemy.GetComponent<EnemyHit_Health>() != null)
            {
                enemy.GetComponent<EnemyHit_Health>().TakeDamage(attackDamage);
                AudioScript.PlayHitSound();
            } 
            else
            {
                Debug.Log("NoEnemyScriptOn" + gameObject.name);
                AudioScript.PlayMissHitSound();
            }
        }
        if (hitEnemies.Length == 0)
            AudioScript.PlayMissHitSound();
        timestamp = Time.time + timeBetweenHits;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    //Player Health ------------------------------------------------------

    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        //find rigidBody
        //find animator
        rigy = gameObject.GetComponent<Rigidbody>();

        anim = gameObject.GetComponent<Animator>();

        currentHealth = PlayerPrefs.GetInt("Health");

        //for when you go through the elevator
        Bottles();
    }

    public void TakeDamage(int damage)
    {
        if (blocking == true || dying)
        {
            return;
        }
            currentHealth -= damage;
            PlayerPrefs.SetInt("Health", currentHealth);

            StartCoroutine(HurtColor(0.2f, 0.3f));

            Bottles();

            if (currentHealth <= 0)
            { 
                Die();
            }
    }

    public void FireBallTakeDamage(int damage)
    {
        currentHealth -= damage;
        PlayerPrefs.SetInt("Health", currentHealth);

        StartCoroutine(HurtColor(0.2f, 0.3f));

        Bottles();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Bottles()
    {
        if (currentHealth <= 75)
            bottle1.GetComponent<Renderer>().material = empty;
        if (currentHealth <= 50)
        {
            bottle2.GetComponent<Renderer>().material = empty;
            bottle3.GetComponent<Renderer>().material = yellow;
            bottle4.GetComponent<Renderer>().material = yellow;
        } 
        if (currentHealth <= 25)
        {
            bottle3.GetComponent<Renderer>().material = empty;
            bottle4.GetComponent<Renderer>().material = red;
        }
        if (currentHealth < 1)
            bottle4.GetComponent<Renderer>().material = empty;
    }

    IEnumerator HurtColor(float flashTime, float dmgTime)
    {
        yield return new WaitForSeconds(dmgTime);
        PlayerRend.material.color = Color.red;
        yield return new WaitForSeconds(flashTime);
        PlayerRend.material.color = Color.white;
    }

    void Die()
    {
        dying = true;
        rigy.constraints = RigidbodyConstraints.FreezePosition;
        gameObject.layer = 1;
        anim.SetTrigger("DieTrigger");
    }

    public void Heal()
    {
        //reset bottles to green
        bottle1.GetComponent<Renderer>().material = green;
        bottle2.GetComponent<Renderer>().material = green;
        bottle3.GetComponent<Renderer>().material = green;
        bottle4.GetComponent<Renderer>().material = green;

        PlayerPrefs.SetInt("Health", maxHealth);
        currentHealth = maxHealth;
    }

    //Other -------------------------------------------------------------

    public void LoadGame()
    {
        Heal();
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
        print("Game loaded!");
    }
}