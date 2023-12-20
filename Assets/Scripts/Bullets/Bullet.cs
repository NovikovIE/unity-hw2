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

        bool isPlayer = other.gameObject.CompareTag("Player");
        bool isEnemy = other.gameObject.CompareTag("Enemy");
        bool isBullet = other.gameObject.CompareTag("Bullet");
        if (isEnemy) {
            Debug.Log("Enemy");
        }

        bool isOwnBullet = (!isEnemyBullet && isPlayer) || (isEnemyBullet && isEnemy) || isBullet;
        bool isDamageBullet = (isEnemyBullet && isPlayer) || (!isEnemyBullet && isEnemy);

        if (isDamageBullet) {
            Destroy(gameObject);
        }

        if (isOwnBullet)
        {
            return;
        }

        Destroy(gameObject);
    }
}