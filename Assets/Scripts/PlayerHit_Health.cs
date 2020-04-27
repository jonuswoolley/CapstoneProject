using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHit_Health : MonoBehaviour
{
    public Text text;

    public Material red;
    public Material green;

    public GameObject bottle1;
    public GameObject bottle2;
    public GameObject bottle3;
    public GameObject bottle4;

    //public Camera cam;
    public Transform attackPoint;
    public float attackRange = 3f;
    public int attackDamage = 40;
    public LayerMask enemyLayers;

    private float timestamp;
    public float timeBetweenHits = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timestamp && Input.GetMouseButtonDown(0))
        {
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

            foreach (Collider enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyHit_Health>().TakeDamage(attackDamage);
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

    //Player Health ------------------------------------------------------

    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = PlayerPrefs.GetInt("Health");
        text.text = currentHealth.ToString();

        //for when you go through the elevator
        if (currentHealth < 80)
            bottle1.GetComponent<Renderer>().material = red;
        if (currentHealth < 60)
            bottle2.GetComponent<Renderer>().material = red;
        if (currentHealth < 40)
            bottle3.GetComponent<Renderer>().material = red;
        if (currentHealth < 20)
            bottle4.GetComponent<Renderer>().material = red;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        PlayerPrefs.SetInt("Health", currentHealth);

        if (currentHealth < 80)
            bottle1.GetComponent<Renderer>().material = red;
        if (currentHealth < 60)
            bottle2.GetComponent<Renderer>().material = red;
        if (currentHealth < 40)
            bottle3.GetComponent<Renderer>().material = red;
        if (currentHealth < 20)
            bottle4.GetComponent<Renderer>().material = red;

        text.text = currentHealth.ToString();

        if (currentHealth <= 0)
        {
            LoadGame();
        }
    }

    public void LoadGame()
    {
        Heal();
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
        print("Game loaded!");
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
        text.text = currentHealth.ToString();
    }
}
