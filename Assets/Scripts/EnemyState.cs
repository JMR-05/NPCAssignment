using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyState : MonoBehaviour
{
    [SerializeField] GameObject waypointSystem;
    [SerializeField] GameObject[] waypoints;

    NavMeshAgent nma;
    int waypointNumber = 0;
    bool isChasing = false;
    GameObject player;

    void Start()
    {
        nma= GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        waypoints = new GameObject[waypointSystem.transform.childCount];

        for(int i = 0; i < waypointSystem.transform.childCount; i++)
        {
            waypoints[i] = waypointSystem.transform.GetChild(i).gameObject;
        }

        nma.SetDestination(waypoints[waypointNumber].transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isChasing)
        {
            return;
        }

        if (other.tag == "Waypoint")
        {
            if (waypointNumber == waypointSystem.transform.childCount-1)
            {
                waypointNumber = 0;
            }
            else
            {
                waypointNumber++;
            }

            nma.SetDestination(waypoints[waypointNumber].transform.position);
        }

        if(other.tag == "Player")
        {
            isChasing = true;

            foreach (EnemyState OtherEnemy in FindObjectsByType<EnemyState>(FindObjectsSortMode.None))
            { 
                OtherEnemy.ChaseThePlayer();
            }
        }
    }

    private void Update()
    {
        if(isChasing)
        {
            nma.SetDestination(player.transform.position);
        }
    }

    void ChaseThePlayer()
    {
        isChasing = true;
    }
}
