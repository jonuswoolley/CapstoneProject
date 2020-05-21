using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Enemy_Controller : MonoBehaviour
{
    Animator EnemyAnim;
    public Transform player;
    public Transform[] points;

    private int destPoint = 0;
    private NavMeshAgent agent;

    void Start()
    {
        EnemyAnim = gameObject.GetComponent<Animator>();
        //player = GameObject.FindWithTag("Player").transform;

        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        //GotoNextPoint();
    }

    /*
    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }
    */

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            agent.enabled = true;
            if (player != null)
            {
                transform.LookAt(player);
            }
            EnemyAnim.SetBool("RunningBool", true);
            agent.destination = player.position - new Vector3(3.0f, 3.0f, 0.0f);
        }
        else
            EnemyAnim.SetBool("RunningBool", false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EnemyAnim.SetBool("RunningBool", false);
            agent.enabled = false;
        }
    }

    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        //if (!agent.pathPending && agent.remainingDistance < 0.5f)
            //GotoNextPoint();
    }
}