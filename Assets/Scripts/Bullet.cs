using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 6f;
    public Vector3 direction;
    public int damage = 1;
    
    public void Move()
    {
        transform.position = transform.position + direction * (bulletSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}