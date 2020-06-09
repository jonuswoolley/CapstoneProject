using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    public Animator ElevatorAnim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            ElevatorAnim.SetTrigger("ElevatorTrigger");
    }
}
