using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet : Bullet
{
    private float expirationDistance = 8f;
    
    public override void Move()
    {
        var distance = bulletSpeed * Time.deltaTime;
        
        transform.position += direction * distance;
        expirationDistance -= distance;
        
        if (expirationDistance <= 0)
        {
            Destroy(gameObject);
        }
    }
        
    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}