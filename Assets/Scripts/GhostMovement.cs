using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    private GameObject player;
    public float speed;
    private float distance;
    public float distanceBetween;

    Rigidbody2D rb;

    private void Start()
    {
        player = GameObject.Find("/Player/PlayerCapsule/GhostFollowPoint");
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
