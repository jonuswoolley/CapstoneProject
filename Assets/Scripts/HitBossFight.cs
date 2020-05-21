using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBossFight : MonoBehaviour
{
    public PlayerHit_Health playerScript;
    public Animator BossAnim;
    bool Hitting = false;


    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        BossAnim.SetBool("SwipeBool", true);
    }

    private void OnTriggerExit(Collider other)
    {
        BossAnim.SetBool("SwipeBool", false);
    }
}
