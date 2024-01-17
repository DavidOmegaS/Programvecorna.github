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

    [SerializeField] AudioSource AS;
    [SerializeField] AudioController AC;

    private Vector2 moveDirection;

    private bool isMoving = true;

    private void Start()
    {
        CrouchSpeed = moveSpeed * CrouchMultiplier;
        animator = GetComponentInChildren<Animator>(); // put a empty object with a sprite to animate
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
        if (Input.GetKeyDown(KeyCode.Space) && IsDashing == false)
        {
            StartCoroutine(DashAbility());
        }

        //maja
        /*if(Input.GetKey(KeyCode.E) && isMoving == true)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            isMoving = false;
        }

        if(Input.GetKey(KeyCode.F) && rb.constraints == RigidbodyConstraints2D.FreezePosition)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            isMoving = true;
        }*/
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

    IEnumerator DashAbility()
    {
        AS.PlayOneShot(AC.clips[3]);
        IsDashing = true;
        animator.SetBool("Dash", true);
        moveSpeed += DashSpeed;
        yield return new WaitForSeconds(0.05f);
        playercollider.enabled = false;
        yield return new WaitForSeconds(0.3f);
        playercollider.enabled = true;
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("Dash", false);
        moveSpeed -= DashSpeed;
        IsDashing = false;
        StopCoroutine(DashAbility());
    }

}
