using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public float lerpValueUpwards;
    public float lerpValueDownwards;

    private void OnEnable()
    {
        PlayerChangePositionEvent.OnYPositionChange += FollowPlayerVertically;
    }

    private void OnDisable()
    {
        PlayerChangePositionEvent.OnYPositionChange -= FollowPlayerVertically;
    }

    private void FollowPlayerVertically(Vector3 playerPosition)
    {
        if (playerPosition.y > transform.position.y + 0.5f)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, playerPosition.y + 3.5f, lerpValueUpwards * Time.deltaTime), transform.position.z);
        }
        else if (playerPosition.y < transform.position.y - 1f)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, playerPosition.y - 1f, lerpValueDownwards * Time.deltaTime), transform.position.z);
        }

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 1.38f, 50f), transform.position.z);
    }
}
