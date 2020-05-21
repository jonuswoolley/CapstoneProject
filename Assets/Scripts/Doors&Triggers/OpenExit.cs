using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenExit : MonoBehaviour
{
    public Animator animExit;

    private void OnTriggerEnter(Collider other)
    {
        animExit.SetTrigger("OpenDoor");
    }
}
