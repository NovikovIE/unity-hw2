using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerGun : MonoBehaviour
{
    protected Transform selfTransform;

    private Camera mainCamera;
    [SerializeField] protected float radius = 1f;

    public Transform player;
    
    public GameObject bulletPrefab;
    [SerializeField] private BulletController bulletController;
    
    private void Start()
    {
        selfTransform = transform;
        mainCamera = Camera.main;
    }
    
    public void RotateWeapon()
    {
        var mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        var position = player.position;
        var direction = mousePos - position;
        
        direction.Normalize();

        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        selfTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        
        selfTransform.position = position + direction * radius;
    }

    public abstract void CreateBullets(Vector3 position);

    protected void SetBulletDirection(Bullet bullet, Vector3 position)
    {
        bullet.direction = position - player.position;
        bullet.direction.z = 0;
        bullet.direction.Normalize();
        
        bulletController.AddBullet(bullet);
    }
    
    public void Shoot()
    {
        var position = selfTransform.position;

        CreateBullets(position);
    }
}
