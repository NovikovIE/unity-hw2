using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperRifle : PlayerGun
{
    SniperRifle()
    {
        fireRate = 1f / 3f;
    }
    
    public override void CreateBullets(Vector3 position)
    {
        GameObject bulletInstance = Instantiate(bulletPrefab, position, selfTransform.rotation);

        Bullet bullet = bulletInstance.GetComponent<Bullet>();
        
        bullet.damage = 15;
        bullet.bulletSpeed = 30;
        
        SetBulletDirection(bullet, position);
    }
}