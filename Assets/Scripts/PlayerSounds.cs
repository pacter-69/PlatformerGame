using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public void PlayFootsepsSFX()
    {
        AudioManager.Instance.PlaySound("Footseps" + Random.Range(1, 4));
    }
    public void PlayJumpSFX()
    {
        AudioManager.Instance.PlaySound("Jump");
    }
}
