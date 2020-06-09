using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public Rigidbody PlayerRigy;
    public Animator PlayerAnimator;

    public IEnumerator SwitchCams(Camera PlayerCam, Camera SwitchCam, int waitTime)
    {
        SwitchCam.enabled = true;
        PlayerRigy.constraints = RigidbodyConstraints.FreezePosition;
        PlayerAnimator.enabled = false;
        PlayerCam.enabled = false;
        //SwitchCam.enabled = true;

        yield return new WaitForSeconds(waitTime);

        SwitchCam.enabled = false;
        PlayerRigy.constraints = ~RigidbodyConstraints.FreezePosition;
        PlayerAnimator.enabled = true;
        PlayerCam.enabled = true;
        //SwitchCam.enabled = false;
    }
}
