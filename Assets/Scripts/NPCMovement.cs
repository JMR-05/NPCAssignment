using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    GameObject player;
    NavMeshAgent nma;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        nma = GetComponent<NavMeshAgent>();

        float randomSpeed = Random.Range(-1, 2);
        nma.speed += randomSpeed;

        float randomAngleSpeed = Random.Range(-1, 10);
        nma.angularSpeed += randomAngleSpeed;

        float randomAccel = Random.Range(-1, 1);
        nma.acceleration += randomAccel;
    }

    void Update()
    {
        nma.SetDestination(player.transform.position);
    }
}
