using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOnStart : MonoBehaviour
{
    bool isEnemySpawn;
    bool beforeBoss;

    public GameObject EnemySpawn;
    public GameObject Player;

    public GameObject BeforeBossRoomBool;
    public GameObject SecondSpawn;
    public TextImporter DisplayText;

    public GameObject MovementTrigger;
    public GameObject JumpTrigger;
    public GameObject EnemyTrigger;
    public GameObject Door_GateTrigger;
    public GameObject GateTrigger;
    public GameObject HealthTrigger;
    public GameObject HealingFountainTrigger;
    public GameObject CamTrigger;


    public void LoadData()
    {
        SaveData data = SaveAndLoad.Load();

        if (data != null)
        {
            isEnemySpawn = data.isEnemySpawn;
            beforeBoss = data.beforeBoss;

            if (isEnemySpawn == true)
            {
                EnemySpawn.SetActive(true);

                MovementTrigger.SetActive(false);
                JumpTrigger.SetActive(false);
                EnemyTrigger.SetActive(false);
                Door_GateTrigger.SetActive(false);

                DisplayText.DisableText();

                Door_GateTrigger.GetComponent<OpenDoor>().OpenAllDoors();

                GateTrigger.SetActive(false);
                HealthTrigger.SetActive(false);
            }
            if (beforeBoss == true)
            {
                BeforeBossRoomBool.SetActive(true);
                Player.SetActive(false);
                Player.transform.position = SecondSpawn.transform.position;
                Player.SetActive(true);


                HealingFountainTrigger.SetActive(false);
                CamTrigger.SetActive(false);
                CamTrigger.GetComponent<OpenExit>().checkpointOpenExit();
            }       
        }
    }
}