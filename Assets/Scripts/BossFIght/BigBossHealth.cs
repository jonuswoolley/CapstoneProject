using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int pillars;

    public void DestroyPillar()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (pillars <= 1)
        {
            Destroy(gameObject);
        }
    }
}
