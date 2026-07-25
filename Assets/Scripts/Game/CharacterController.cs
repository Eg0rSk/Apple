using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float jumpForce = 6f;

    private Animator animator;
    private AudioSource audioSource;
    private GroundChecker groundChecker;
    private Rigidbody rb;
    private float currentRotationY = 0f;
    
    public AudioSource footsteps;
    public AudioClip jumpSound;
    public AudioSource audioSource1;
    
    private bool canPlayFootsteps = true;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        groundChecker = GetComponent<GroundChecker>();
        audioSource1 = GetComponent<AudioSource>();
    }

    private void Update()
    {
        HandleInput();
        HandleAnimation();
        HandleFootsteps();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }
    
    private void HandleInput()
    {
        if (Input.GetButtonDown("Jump") && groundChecker.isGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetTrigger("Jump");
            audioSource1.PlayOneShot(jumpSound);
        }

        if (Input.GetButton("Fire1"))
        {
            animator.SetInteger("Attack", 1);
        }
        else if (Input.GetButton("Fire2"))
        {
            animator.SetInteger("Attack", 2);
        }
        else
        {
            animator.SetInteger("Attack", 0);
        }
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        currentRotationY += horizontal * rotationSpeed;
        transform.rotation = Quaternion.Euler(0, currentRotationY, 0);

        Vector3 direction = transform.forward * vertical * speed;
        direction.y = rb.linearVelocity.y;

        rb.linearVelocity = direction;
    }

    private void HandleAnimation()
    {
        bool isGroundCheck = groundChecker.isGround;

        float horizontal = Mathf.Abs(Input.GetAxis("Horizontal"));
        float vertical = Mathf.Abs(Input.GetAxis("Vertical"));

        animator.SetFloat("Speed", horizontal + vertical);
    }
    
    private void HandleFootsteps()
    {
        if (!canPlayFootsteps)
        {
            if (footsteps.isPlaying)
                footsteps.Stop();
            return;
        }

        float vertical = Mathf.Abs(Input.GetAxis("Vertical"));
        float horizontal = Mathf.Abs(Input.GetAxis("Horizontal"));

        bool isMoving = vertical > 0.1f || horizontal > 0.1f;

        if (isMoving && groundChecker.isGround)
        {
            if (!footsteps.isPlaying)
                footsteps.Play();
        }
        else
        {
            if (footsteps.isPlaying)
                footsteps.Stop();
        }
    }
    public void DisableFootsteps()
    {
        canPlayFootsteps = false;

        if (footsteps.isPlaying)
            footsteps.Stop();
    }
}

