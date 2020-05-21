using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillars : MonoBehaviour
{
    public PillarCount PillarCountScript;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fireball"))
        {
            PillarCountScript.DestroyPillar();
        }
    }
}
