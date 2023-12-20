using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    public Rigidbody2D rb;
    public Animator animator;

    private Vector2 movement;

    [SerializeField] private PlayerGun gun;
    private bool isShooting = false;
    public UpgradeProducts upgradeProducts;
    public float health = 20.0f;
    float damageMultiplier = 1.0f;

    [SerializeField] private GameObject timerObject;
    private Timer timer;
    
    private void Start()
    {
        if (PlayerPrefs.HasKey("health") == false)
        {
            PlayerPrefs.SetInt("health", 0); // пример значения
        }

        if (PlayerPrefs.HasKey("damage") == false)
        {
            PlayerPrefs.SetInt("damage", 0); // пример значения
        }

        timer = timerObject.GetComponent<Timer>();
        
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
    
    IEnumerator EndGame()
    {
        Destroy(gun);
        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(2);
        Destroy(gameObject);
        Time.timeScale = 1;

        SceneManager.LoadScene("Upgrade");
    }

    public void TakeDamage(float damage)
    {
        health -= damage;


        if (health <= 0)
        {
           
            if (PlayerPrefs.HasKey("ups") == false)
            {
              PlayerPrefs.SetInt("ups", 0); // пример значения
            }
            int ups = PlayerPrefs.GetInt("ups");
            PlayerPrefs.DeleteKey("ups");
            PlayerPrefs.SetInt("ups", ups + 1);
            StartCoroutine(EndGame());
        }
    }

    public void StatusUpdate()
    {
        if (PlayerPrefs.HasKey("health"))
        {
            health = 20 + 5 * PlayerPrefs.GetInt("health");
        }

        if (PlayerPrefs.HasKey("damage"))
        {
            int damage = PlayerPrefs.GetInt("damage");
            damageMultiplier = 1.0f * (float)(Math.Pow(1.2f, damage));
        }

        gun.SetMultiplier(damageMultiplier);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
        // upgradeProducts.ProductUpgrade();
        if (timer.GetTime() <= 0)
        {
            StartCoroutine(EndGame());
        }
    }
}