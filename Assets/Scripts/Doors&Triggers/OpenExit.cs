using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenExit : MonoBehaviour
{
    public Animator animExit;
    public GameObject exitCollider;

    private void OnTriggerEnter(Collider other)
    {
        checkpointOpenExit();
    }

    public void checkpointOpenExit()
    {
        animExit.SetTrigger("OpenDoor");
        Destroy(exitCollider);
    }
}
