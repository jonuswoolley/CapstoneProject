using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Animator animDoor;
    public Animator animGate;
    public Animator animLever;

    public GameObject doorCollider;
    public GameObject gateCollider;
    public TextImporter DisplayText;

    public CamSwitch CamSwitch;

    public Camera PlayerCam;
    public Camera SwitchCam;
    public int waitTime;

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
            animLever.SetTrigger("LeverTrigger");

            animDoor.SetTrigger("OpenDoor");
            Destroy(doorCollider);

            CamSwitch.StartCoroutine(CamSwitch.SwitchCams(PlayerCam, SwitchCam, waitTime));

            animGate.SetTrigger("OpenDoor");
            Destroy(gateCollider);

            DisplayText.DisableText();
            Destroy(gameObject);
        }
    }
    
}
