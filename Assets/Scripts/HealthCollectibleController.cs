using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectibleController : MonoBehaviour
{
    [SerializeField]
    float amount;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered: " + other);
        var player = other.GetComponent<PlayerController>();
        if (player == null)
            return;
        if (player.Health < player.maxHealth)
        {
            player.ChangeHealth(amount);
            Destroy(gameObject);
        }
    }
}
