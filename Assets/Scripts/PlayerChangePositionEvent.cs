using UnityEngine;

public class PlayerChangePositionEvent : MonoBehaviour
{
    private float previousYPosition;
    private float currentYPosition;

    public delegate void YPositionChangeDelegate(Vector3 p);
    public static event YPositionChangeDelegate OnYPositionChange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        previousYPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        currentYPosition = transform.position.y;
        if (previousYPosition != currentYPosition)
        {
            OnYPositionChange.Invoke(transform.position);
        }
    }
}
