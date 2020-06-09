using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PillarCount : MonoBehaviour
{
    public int PillarsLeft;
    public GameObject Boss;
    public GameObject BossParticles;
    public HealthBarController healthBarScript;
    public GameObject ColliderDoor;
    public Animator wizardCellAnim;
    public GameObject Wizard;
    public GameObject wizFake;

    public CamSwitch CamSwitchScript;
    public Camera PlayerCam;
    public Camera WizCam;

    private void Update()
    {
        if (PillarsLeft <= 0)
        {
            Destroy(Boss);
            Destroy(BossParticles);

            SpawnWiz();
        }
    }

    public void DestroyPillar()
    {
        PillarsLeft--;
        healthBarScript.HealthBarDMG(.25f);
    } 

    public void SpawnWiz()
    {
        CamSwitchScript.StartCoroutine(CamSwitchScript.SwitchCams(PlayerCam, WizCam, 3));

        healthBarScript.SwitchHealthBars();
        wizardCellAnim.SetTrigger("OpenCell");
        Debug.Log("Past Trigger");
        ColliderDoor.SetActive(false);
        Wizard.SetActive(true);
        wizFake.SetActive(false);
        Destroy(this);
    }
}
