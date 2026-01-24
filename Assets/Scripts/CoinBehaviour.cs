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
        OnCoinCollected?.Invoke(value);
        Destroy(gameObject);
    }
}