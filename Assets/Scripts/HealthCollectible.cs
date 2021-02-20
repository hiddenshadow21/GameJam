using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    [SerializeField]
    float amount;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered: " + other);
        var player = other.GetComponent<PlayerController>();
        if (player == null || player.Health == player.maxHealth )
            return;

        player.ChangeHealth(amount);
        Destroy(gameObject);
    }
}
