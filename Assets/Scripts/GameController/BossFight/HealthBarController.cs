using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    public GameObject HealthBar;
    public GameObject HealthBarContainer;

    public GameObject VoidMonsterHealthBar;
    public GameObject WizardHealthBar;

    public void HealthBarDMG(float scale)
    {
        HealthBar.transform.localScale -= new Vector3(scale, 0);
    }

    public void SwitchHealthBars()
    {
        VoidMonsterHealthBar.SetActive(false);
        WizardHealthBar.SetActive(true);

        HealthBar.transform.localScale = new Vector3(1, 1, 1);
    }

    public void DestroyHealthBar()
    {
        HealthBarContainer.SetActive(false);
    }
}
