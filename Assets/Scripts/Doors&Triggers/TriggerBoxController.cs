using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoxController : MonoBehaviour
{
    //Scripts
    public CamSwitch CamSwitch;
    public TextImporter DisplayText;

    //Cams
    public Camera PlayerCam = null;
    public Camera SwitchCam = null;

    //Text
    public int textIndex;
    public int waitTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && PlayerCam != null && SwitchCam != null)
        {
            DisplayText.StartCoroutine(DisplayText.DisplayTextTimed(textIndex, waitTime));
            CamSwitch.StartCoroutine(CamSwitch.SwitchCams(PlayerCam, SwitchCam, waitTime));
            Destroy(gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            DisplayText.DisplayText(textIndex);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DisplayText.DisableText();
        }
    }
}
