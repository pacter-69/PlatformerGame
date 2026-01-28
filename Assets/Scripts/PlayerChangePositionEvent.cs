using UnityEngine;

public class PlayerChangePositionEvent : MonoBehaviour
{
    private float previousYPosition;
    private float currentYPosition;

    public delegate void YPositionChangeDelegate(Vector3 p);
    public static event YPositionChangeDelegate OnYPositionChange;

    void Start()
    {
        previousYPosition = transform.position.y;
    }

    void Update()
    {
        currentYPosition = transform.position.y;

        if (previousYPosition != currentYPosition)
        {
            OnYPositionChange.Invoke(transform.position);
        }
    }
}