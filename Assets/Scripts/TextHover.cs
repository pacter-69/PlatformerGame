using UnityEngine;

public class TextHover : MonoBehaviour
{
    private float initalYPosition;
    public float sinusSpeed;
    public float sinusAmplitude;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initalYPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float sinus = Mathf.Sin(Time.timeSinceLevelLoad * sinusSpeed) * sinusAmplitude;
        transform.position = new Vector3(transform.position.x, initalYPosition + sinus, transform.position.z);
    }
}
