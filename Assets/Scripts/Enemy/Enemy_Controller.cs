using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Enemy_Controller : MonoBehaviour
{
    Animator EnemyAnim;
    public Transform player;
    public Transform[] points;

    public float DistanceFromPlayer = 3;

    //private int destPoint = 0;
    private NavMeshAgent agent;

    

    void Start()
    {
        EnemyAnim = gameObject.GetComponent<Animator>();
        if (EnemyAnim == null)
            Debug.Log("EnemyAnim NotFound");
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
            var dist = Vector3.Distance(other.transform.position, gameObject.transform.position);
            //Debug.Log(dist);
            agent.enabled = true;
            if (player != null)
            {
                transform.LookAt(player);
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
                EnemyAnim.SetBool("RunningBool", true);
                agent.destination = player.position;
            }
            if (dist <= DistanceFromPlayer)
            {
                EnemyAnim.SetBool("RunningBool", false);
                agent.destination = gameObject.transform.position;
            }
        }
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
        //transform.LookAt(player);
    }

    /*
    public void TurnOffAgent()
    {
        agent.enabled = false;
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        Debug.Log("TurnOffAgent");
    }
    */

    public void turnOff()
    {
        agent.enabled = false;
    }
}