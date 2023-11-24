using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : PlayerGun
{
    Pistol()
    {
        fireRate = 1f;
    }
    
    public override void CreateBullets(Vector3 position)
    {
        GameObject bulletInstance = Instantiate(bulletPrefab, position, selfTransform.rotation);

        Bullet bullet = bulletInstance.GetComponent<Bullet>();
        
        bullet.damage = 5;
        bullet.bulletSpeed = 5;
        
        SetBulletDirection(bullet, position);
    }
}