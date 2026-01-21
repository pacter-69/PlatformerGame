using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    public int Value = 5;

    // 1. C# delegate type and object (C# 6.0)
    //public delegate void CoinCollectedDelegate(Coin coin);
    //public static event CoinCollectedDelegate OnCoinCollected;

    // 2. Action<T> Delegate
    // Encapsulates a method that has a single parameter and
    // does not return a value
    public static Action<Coin> OnCoinCollected;

    // 3. UnityEvents are a way of allowing user driven callback (delegates)
    // https://docs.unity3d.com/Manual/UnityEvents.html
    //public UnityEvent OnCoinCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Call any method subscrived to the event
        //SendMessage("OnCoinCollected", this);
        OnCoinCollected?.Invoke(this);

        Destroy(gameObject);
    }
}