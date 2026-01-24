using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public int Height = 0;

    //public delegate void OnScoredDelegate(int score);
    //public static event OnScoredDelegate OnScored;

    public static Action<int> OnHeightUpdated;
    private void OnEnable()
    {
        PowerUp.OnPowerUpCollected += UpdateHeight;
    }
    private void OnDisable()
    {
        Coin.OnCoinCollected -= UpdateHeight;
    }
    private void UpdateHeight(int value)
    {
        Height += value;
        OnHeightUpdated?.Invoke(Height);
    }
}
