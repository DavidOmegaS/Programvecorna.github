using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    [SerializeField] BoxCollider2D playercollider;
    public float CrouchSpeed;
    [SerializeField] float CrouchMultiplier;
    public bool IsCrouching;
    public bool IsDashing;
    [SerializeField] float DashSpeed;
    Animator animator;
    public bool IsWalking; // for audiocontroller - benjamin

    private Vector2 moveDirection;

    private bool isMoving = true;

    private void Start()
    {
        CrouchSpeed = moveSpeed * CrouchMultiplier;
        IsDashing = false;
        animator = GetComponentInChildren<Animator>();
        animator.SetBool("Walk", false);
        animator.SetBool("Dash", false);
    }
    void Update() //processing inputs
    {
        ProcessInputs();

        if (Input.GetKey(KeyCode.LeftControl)) // Holding left control makes the character move slower (crouchmodifier * movespeed) and reduce the size of the hitbox (harder to detect)
        {
            IsCrouching = true;
            playercollider.size = new Vector2(0.3f, 0.3f);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl)) // disables crouch and sets collider back to normal
        {
            IsCrouching = false;
            playercollider.size = new Vector2(1, 1);
        }
        if (Input.GetKey(KeyCode.Space) && !IsDashing)
        {
            // StartCoroutine(DashAbility());
        }

        if(Input.GetKeyDown(KeyCode.E) && isMoving == true)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            isMoving = false;
        }

        if(Input.GetKeyDown(KeyCode.E) && isMoving == false)
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }
    }

    void FixedUpdate() //physics calculations
    {
        Move();
    }

    void ProcessInputs()
    {
        float MoveX = Input.GetAxisRaw("Horizontal");
        float MoveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(MoveX, MoveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * (IsCrouching ? CrouchSpeed : moveSpeed), moveDirection.y * (IsCrouching ? CrouchSpeed : moveSpeed));
        if(Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Vertical") == -1 || Input.GetAxisRaw("Horizontal") == -1)
        {
            animator.SetBool("Walk", true);
            IsWalking = true;
        }
        else
        {
            animator.SetBool("Walk", false);
            IsWalking = false;
        }
    }

    /*IEnumerator DashAbility()
    {
        animator.SetBool("Dash", true);
        IsDashing = true;
        moveSpeed += DashSpeed;
        yield return new WaitForSeconds(0.05f);
        playercollider.enabled = false;
        yield return new WaitForSeconds(0.3f);
        playercollider.enabled = true;
        moveSpeed -= DashSpeed;
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("Dash", false);
        IsDashing = false;
    }*/

}
