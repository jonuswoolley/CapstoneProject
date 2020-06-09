using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBossCast : MonoBehaviour
{
    public Transform Player;
    public Transform CastPoint;
    public GameObject FireBallPrefab;

    public Animator BossAnim;
    public Audio AudioScript;

    GameObject FireBall;

    public int FireballSpeed;

    public float TimeBetweenCasts = 1.0f;
    private float timestamp;

    private void Start()
    {
        timestamp = Time.time + TimeBetweenCasts;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(Player);

        if (Time.time >= timestamp)
        {
            Cast();
            timestamp = Time.time + TimeBetweenCasts;
            TimeBetweenCasts = Random.Range(1, 3);
        }
    }

    public void Cast()
    {
        BossAnim.SetTrigger("CastTrigger");
        AudioScript.FireballSound();
        FireBall = Instantiate(FireBallPrefab, CastPoint.position, CastPoint.rotation) as GameObject;
        Rigidbody rigy = FireBall.GetComponent<Rigidbody>();
        rigy.velocity = (Player.position - CastPoint.position).normalized * FireballSpeed;
    }
}
