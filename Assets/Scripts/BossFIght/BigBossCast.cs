using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBossCast : MonoBehaviour
{
    public Transform Player;
    public Transform CastPoint;
    public GameObject FireBallPrefab;

    public Animator BossAnim;

    GameObject FireBall;

    public int FireballSpeed;

    public float TimeBetweenCasts = 1.0f;
    private float timestamp;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timestamp)
        {
            Cast();
            timestamp = Time.time + TimeBetweenCasts;
        }
    }

    public void Cast()
    {
        BossAnim.SetTrigger("CastTrigger");
        FireBall = Instantiate(FireBallPrefab, CastPoint.position, CastPoint.rotation) as GameObject;
        Rigidbody rigy = FireBall.GetComponent<Rigidbody>();
        rigy.velocity = (Player.position - CastPoint.position).normalized * FireballSpeed;
    }
}
