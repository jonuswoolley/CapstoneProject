using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SaveData
{
    public bool isEnemySpawn;
    public bool beforeBoss;

    public SaveData()
    {
        if (GameObject.Find("EnemySpawn"))
        {
            isEnemySpawn = true;
            //Debug.Log(isEnemySpawn);
        }  
        else
        {
            isEnemySpawn = false;
            //Debug.Log(isEnemySpawn);
        }
        if (GameObject.Find("BeforeBossRoomBool"))
        {
            beforeBoss = true;
            //Debug.Log(beforeBoss);
        }
        else
        {
            beforeBoss = false;
            //Debug.Log(beforeBoss);
        }
    }
}
