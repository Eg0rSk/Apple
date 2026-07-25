using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool isGround = true;
    private Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Wall")
        {
            isGround = true;
            animator.SetBool("IsGround", isGround);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Wall")
        {
            isGround = false;
            animator.SetBool("IsGround", isGround);
        }
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
}


