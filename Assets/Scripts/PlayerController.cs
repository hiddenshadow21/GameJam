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
    [SerializeField]
    private LevelManager manager;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 2; //maxHealth;
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
        if ((horizontal < 0 && !isFacingRight) || (horizontal > 0 && isFacingRight))
            Flip();

        float vertical = Input.GetAxis("Vertical")* speedY * Time.deltaTime;
        var moveDir = new Vector2(Mathf.Abs(horizontal),vertical);
        animator.SetFloat("Speed", Mathf.Abs(moveDir.magnitude));

        transform.Translate(moveDir);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;

        transform.Rotate(0f,180f,0f);
    }

    public void ChangeHealth(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UpdateUILives();
        if (currentHealth == 0)
        {
            if (ReviveAvailable)
            {
                Revive();
                return;
            }

            animator.SetTrigger("Death");
            MonoBehaviour[] scripts = gameObject.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour script in scripts)
            {
                script.enabled = false;
            }
        }
        if (amount < 0)
            animator.SetTrigger("Damaged");
        Debug.Log($"{currentHealth}/{maxHealth}");
    }

    private void Revive()
    {
        throw new NotImplementedException();
    }

    public void Death()
    {
        manager.GameOver();
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
