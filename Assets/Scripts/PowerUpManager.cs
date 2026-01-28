using System;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public int Height = 0;

    public static event Action<int> OnHeightUpdated;

    private void OnEnable()
    {
        PowerUp.OnPowerUpCollected += UpdateHeight;
        Height = 0;
    }

    private void OnDisable()
    {
        PowerUp.OnPowerUpCollected -= UpdateHeight;
    }

    private void UpdateHeight(int value)
    {
        OnHeightUpdated?.Invoke(value);
    }
}