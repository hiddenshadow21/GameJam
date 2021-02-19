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

    // Start is called before the first frame update
    void Start()
    {
        
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
}
