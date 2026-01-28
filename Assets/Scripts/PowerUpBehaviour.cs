using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int value;

    public delegate void CoinCollectedDelegate(int value);
    public static event CoinCollectedDelegate OnPowerUpCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        GetComponent<BoxCollider2D>().enabled = false;
        OnPowerUpCollected?.Invoke(value);
        Destroy(gameObject);
    }
}