using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    float health = 20f;

    public Rigidbody2D rb;
    public Animator animator;

    private Vector2 movement;
    
    [SerializeField] private PlayerGun gun;
    private bool isShooting = false;
    
    private void HandleMovementInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
    
    private void Update()
    {
        HandleMovementInput();
        gun.RotateWeapon();
        
        if (Input.GetMouseButtonDown(0))
        {
            isShooting = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isShooting = false;
        }

        if (isShooting)
        {
            gun.Shoot();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

     public void TakeDamage(float damage) {
        health -= damage;


        if (health <= 0)
        {
            Destroy(gun);
            Destroy(gameObject);
        }
    }
}