using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsualBullet : Bullet
{
    public override void Move()
    {
        transform.position += direction * (bulletSpeed * Time.deltaTime);
    }
}