using System;
using UnityEngine;

public class PowerUpBehaviour : MonoBehaviour
{
    public static Action OnPowerUpCollected;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnPowerUpCollected?.Invoke();
        Destroy(collision.gameObject);
    }
}
