using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public float bulletSpeed = 6f;
    public Vector3 direction;
    public int damage = 1;

    public abstract void Move();

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}