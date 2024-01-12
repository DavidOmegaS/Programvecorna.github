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
    bool IsDashing;
    [SerializeField] float DashSpeed;

    private Vector2 moveDirection;

    private void Start()
    {
        CrouchSpeed = moveSpeed * CrouchMultiplier;
        IsDashing = false;
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
            StartCoroutine(DashAbility());
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
    }

    IEnumerator DashAbility()
    {
        IsDashing = true;
        moveSpeed += DashSpeed;
        yield return new WaitForSeconds(0.05f);
        playercollider.enabled = false;
        yield return new WaitForSeconds(0.3f);
        playercollider.enabled = true;
        moveSpeed -= DashSpeed;
        yield return new WaitForSeconds(0.5f);
        IsDashing = false;
    }

}
