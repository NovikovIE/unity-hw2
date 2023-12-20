using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 spawnPoint;
    Vector2 randomPoint;
    public float radius = 15.0f;

    MapGenerator mapGenerator;

    Transform player;

    float last_point_pick = 0.0f;

    //states enum
    public enum State
    {
        attack,
        stagger
    }

    State state = State.stagger;


    [SerializeField] private EnemyGun gun;
    // private bool isShooting = false;

    void Start()
    {
        spawnPoint = transform.position;
        randomPoint = spawnPoint;
        mapGenerator = GameObject.FindWithTag("MapGenerator").GetComponent<MapGenerator>();
        player = GameObject.FindWithTag("Player").transform;
    }

    //get random point in a circle
    private Vector2 GetRandomPointInCircle(float radius)
    {
        float angle = UnityEngine.Random.Range(0f, Mathf.PI * 2f);
        float distance = Mathf.Sqrt(UnityEngine.Random.Range(0.5f, 1f)) * radius;

        float x = spawnPoint.x + Mathf.Cos(angle) * distance;
        float y = spawnPoint.y + Mathf.Sin(angle) * distance;

        return new Vector2(x, y);
    }

    //function to move randomly around the spawnpoint
    private void WalkAround()
    {
        //check if close enough to randomPoint
        if (Vector2.Distance(transform.position, randomPoint) < 0.1f || (Time.time - last_point_pick) > 3.0f)
        {
            do
            {
                randomPoint = GetRandomPointInCircle(radius);
            } while (!mapGenerator.CheckPointIsClear(randomPoint));
            last_point_pick = Time.time;
        }

        //move to random point
        transform.position = Vector2.MoveTowards(transform.position, randomPoint, moveSpeed * Time.deltaTime);
    }

    private void Update()
    {
        gun.RotateWeapon();
        if (Vector2.Distance(transform.position, player.position) < 6f) {
            state = State.attack;
        }
        if (Vector2.Distance(transform.position, player.position) > 8f) {
            state = State.stagger;
        }

        switch (state) 
        {
            case State.attack:
            {
                gun.Shoot();
                break;
            }
            case State.stagger: 
            {
                WalkAround();
                break;
            }
        }
    }
}