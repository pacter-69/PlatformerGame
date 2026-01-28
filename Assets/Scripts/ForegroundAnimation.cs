using UnityEngine;

public class ForegroundAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetTrigger("PlayAnimation");
    }
}
