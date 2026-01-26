using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{

    public int value;
    public delegate void CoinCollectedDelegate(int value);
    public static event CoinCollectedDelegate OnCoinCollected;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        OnCoinCollected?.Invoke(value);
        AudioManager.Instance.PlaySound("Pickup");
        Destroy(gameObject);
    }
}