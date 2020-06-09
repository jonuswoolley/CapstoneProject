using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame : MonoBehaviour
{
    //If the new game has been slelected set up player health

    public GameObject player;
    public PlayerHit_Health heal;

    void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        //heal = player.GetComponent<PlayerHit_Health>();
        //if (heal != null)
            heal.Heal();
    }
}
