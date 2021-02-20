using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speedX = 1;
    [SerializeField]
    float speedY = 1;
    public float maxHealth = 3;

    public float Health { get { return currentHealth; } }

    float currentHealth;

    public bool ReviveAvailable { get { return revive; } }
    [SerializeField]
    private bool revive = false;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 2;// maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal")* speedX * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical")* speedY * Time.deltaTime;
        var moveDir = new Vector2(horizontal,vertical);
        transform.Translate(moveDir);
    }

    public void ChangeHealth(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log($"{currentHealth}/{maxHealth}");
    }

    public void AddRevive()
    {
        revive = true;
    }
}
