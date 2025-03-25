using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] GameObject waypointSystem;
    [SerializeField] GameObject[] waypoints;
    [SerializeField] float stoppingDistance;



    NavMeshAgent nma;
    int waypointNumber = 0;

    bool isChasing = false;
    GameObject player;

   
    void Start()
    {
        nma= GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        PopulateWaypointArray();
    }

    void PopulateWaypointArray()
    {
        waypoints = new GameObject[waypointSystem.transform.childCount];
        for (int i = 0; i < waypointSystem.transform.childCount; i++)
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

        if (other.tag == "WayPoint")
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

            foreach (EnemyMovement OtherEnemy in FindObjectsByType<EnemyMovement>(FindObjectsSortMode.None))
            { 
                OtherEnemy.ChaseThePlayer();
            }
        }
    }

    private void Update()
    {
        if(isChasing)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < stoppingDistance)
            {
                nma.speed = 0.01f;
                GetComponent<NavMeshAgent>().enabled = false;
            }
            else
            {
                GetComponent<NavMeshAgent>().enabled = true;
                nma.speed = 3.5f;
                nma.SetDestination(player.transform.position);
            }
        }
    }


    void ChaseThePlayer()
    {
        isChasing = true;
    }
}
