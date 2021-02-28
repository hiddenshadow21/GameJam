using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speedX = 1;
    [SerializeField]
    float speedY = 1;
    private bool isFacingRight;

    public float maxHealth = 3;
    public float Health { get { return currentHealth; } }
    [SerializeField]
    private float currentHealth;

    public bool ReviveAvailable { get { return revive; } }
    [SerializeField]
    private bool revive = false;


    //UI
    [SerializeField]
    private Image[] lives;
    [SerializeField]
    private Sprite fullHP;
    [SerializeField]
    private Sprite noHP;
    [SerializeField]
    private Image reviveImg;

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        reviveImg.enabled = false;
        UpdateUILives();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal")* speedX * Time.deltaTime;
        if (horizontal < 0 && !isFacingRight)
            Flip();
        if (horizontal > 0 && isFacingRight)
            Flip();

        float vertical = Input.GetAxis("Vertical")* speedY * Time.deltaTime;
        var moveDir = new Vector2(horizontal,vertical);
        animator.SetFloat("Speed", Mathf.Abs(moveDir.magnitude));

        transform.Translate(moveDir);
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        isFacingRight = !isFacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void ChangeHealth(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UpdateUILives();
        Debug.Log($"{currentHealth}/{maxHealth}");
    }

    private void UpdateUILives()
    {
        for (int i = 0; i < lives.Length; i++)
        {
            lives[i].sprite = (i < currentHealth ? fullHP : noHP);
            if (i >= maxHealth)
                lives[i].enabled = false;
            else
                lives[i].enabled = true;
        }
    }

    public void AddRevive()
    {
        revive = true;
        reviveImg.enabled = true;
    }
}
