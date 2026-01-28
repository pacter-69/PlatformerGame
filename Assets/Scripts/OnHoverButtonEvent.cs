using UnityEngine;

public class OnHoverButtonEvent : MonoBehaviour
{
    private void OnMouseOver()
    {
        AudioManager.Instance.PlaySound("Hover");
    }

    public void PlayClickSFX()
    {
        AudioManager.Instance.PlaySound("Select");
    }
}