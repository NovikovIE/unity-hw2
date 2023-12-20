using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public float bulletSpeed = 6f;
    public Vector3 direction;
    public int damage = 1;
    public Rigidbody2D rb;
    public bool isEnemyBullet = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public abstract void Action();

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("bullet collision");

        bool isPlayer = other.gameObject.CompareTag("Player");
        bool isEnemy = other.gameObject.CompareTag("Enemy");

        bool isOwnBullet = (!isEnemyBullet && isPlayer) || (isEnemyBullet && isEnemy);
        bool isElseBullet = (isEnemyBullet && !isPlayer) || (!isEnemyBullet && !isEnemy);

        if (isOwnBullet)
        {
            return;
        }

        if (isElseBullet)
        {
            // make damage
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }
}