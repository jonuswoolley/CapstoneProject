using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public class PlayerData : MonoBehaviour
{
    public int health;
    public float[] position;
    public string savedScene = "TestRoom";

    public PlayerData (PlayerHit_Health PlayerHit_Health)
    {
        //health = PlayerHit_Health.currentHealth;

        position = new float[3];
        position[0] = PlayerHit_Health.transform.position.x;
        position[1] = PlayerHit_Health.transform.position.y;
        position[2] = PlayerHit_Health.transform.position.z;
    }
}
