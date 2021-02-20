using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered: " + other);
        var player = other.GetComponent<PlayerController>();
        if (player == null || player.ReviveAvailable)
            return;

        Debug.Log("Added revive");
        player.AddRevive();
        Destroy(gameObject);
    }
}
