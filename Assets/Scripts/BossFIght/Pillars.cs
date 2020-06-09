using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillars : MonoBehaviour
{
    public GameObject beam;
    public PillarCount PillarCountScript;
    public Audio AudioScript;
    Animator PillarAnim;

    private void Start()
    {
        PillarAnim = gameObject.GetComponent<Animator>();
        Debug.Log(PillarAnim);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fireball"))
        {
            PillarAnim.SetTrigger("DestroyTrigger");
            PillarCountScript.DestroyPillar();
            AudioScript.PillarDestroySound();
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            beam.SetActive(false);
        }
    }
}
