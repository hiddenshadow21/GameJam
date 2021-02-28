using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Transform punchPoint;
    [SerializeField]
    private Transform kickPoint;
    [SerializeField]
    private float attackRange = 0.5f;
    [SerializeField]
    private LayerMask enemyLayers;

    [SerializeField]
    private float attackRate = 2f;
    float nextAttackTime;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("Attack 1");
                Punch();
                nextAttackTime = Time.time + 1f / attackRate;
            }
            if (Input.GetButtonDown("Fire2"))
            {
                nextAttackTime = Time.time + 1f / attackRate;
                Kick();
                Debug.Log("Attack 2");
            }
        }
    }

    private void Punch()
    {
        animator.SetTrigger("Punch");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(punchPoint.position, attackRange, enemyLayers);

        foreach (var enemy in hitEnemies)
        {
            Debug.Log("Enemy hit");
        }
    }

    private void Kick()
    {
        animator.SetTrigger("Kick");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(kickPoint.position, attackRange, enemyLayers);

        foreach (var enemy in hitEnemies)
        {
            Debug.Log("Enemy hit");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(punchPoint.position, attackRange);
        Gizmos.DrawWireSphere(kickPoint.position, attackRange);
    }
}
