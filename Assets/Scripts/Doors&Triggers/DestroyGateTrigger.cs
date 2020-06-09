using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGateTrigger : MonoBehaviour
{
    public GameObject GateTrigger;

    bool triggerEnter = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerEnter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerEnter = false;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && triggerEnter == true)
        {
            if (GateTrigger != null)
                Destroy(GateTrigger);
        }
    }
}
