using UnityEngine;

public class TextHover : MonoBehaviour
{
    private float initalYPosition;
    public float sinusSpeed;
    public float sinusAmplitude;

    void Start()
    {
        initalYPosition = transform.position.y;
    }

    void Update()
    {
        float sinus = Mathf.Sin(Time.timeSinceLevelLoad * sinusSpeed) * sinusAmplitude;
        transform.position = new Vector3(transform.position.x, initalYPosition + sinus, transform.position.z);
    }
}