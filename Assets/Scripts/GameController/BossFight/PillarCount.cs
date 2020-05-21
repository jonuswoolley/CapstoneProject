using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarCount : MonoBehaviour
{
    public int PillarsLeft;
    public GameObject Boss;

    private void Update()
    {
        if (PillarsLeft <= 0)
        {
            Destroy(Boss);
        }
    }

    public void DestroyPillar()
    {
        PillarsLeft--;
    }

    
}
