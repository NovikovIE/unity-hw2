using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public float moveSpeed = 5.0f;

  public Rigidbody2D rb;
  public Animator animator;

  private Vector2 movement;

  [SerializeField] private PlayerGun gun;
  private bool isShooting = false;
  public UpgradeProducts upgradeProducts;
  public int health;

  private void Start()
  {
    if (PlayerPrefs.HasKey("health") == false)
    {
      PlayerPrefs.SetInt("health", health); // пример значения
    }
    if (PlayerPrefs.HasKey("damage") == false)
    {
      PlayerPrefs.SetInt("damage", 3); // пример значения
    }
    StatusUpdate();
  }

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

  public void StatusUpdate()
  {
    if (PlayerPrefs.HasKey("health"))
    {
      health = PlayerPrefs.GetInt("health");
    }
    if (PlayerPrefs.HasKey("damage"))
    {
      int damage = PlayerPrefs.GetInt("damage");
    }
  }

  private void FixedUpdate()
  {
    rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    upgradeProducts.ProductUpgrade();
  }
}