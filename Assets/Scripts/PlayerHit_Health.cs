using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHit_Health : MonoBehaviour
{
    public Text text;

    public Camera cam;
    public Transform attackPoint;
    public float attackRange = 3f;
    public int attackDamage = 40;
    public LayerMask enemyLayers;

    private float timestamp;
    public float timeBetweenHits = 0.5f;

    //Quaternion startRot, endRot;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timestamp && Input.GetMouseButtonDown(0))
        {
            //startRot = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
            //endRot = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);

            //StartCoroutine(RotateImage());
            //transform.rotation = Quaternion.Slerp( transform.rotation, Quaternion.Euler(0 , Camera.main.transform.eulerAngles.y, 0), 10 * Time.time);

            Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

            foreach(Collider enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyHit_Health>().TakeDamage(attackDamage);
            }
            timestamp = Time.time + timeBetweenHits;
        }

        //if (transform.rotation != endRot)
            //transform.rotation = Quaternion.Slerp(startRot, endRot, Time.time * 10);
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

    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        text.text = currentHealth.ToString();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        text.text = currentHealth.ToString();

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator RotateImage()
    {
        float moveSpeed = 0.1f;
        while (transform.rotation.y < Camera.main.transform.eulerAngles.y)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0), moveSpeed * Time.time);
            yield return null;
        }
        //transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
       // yield return null;
    }
}
