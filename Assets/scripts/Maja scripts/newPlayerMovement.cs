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

    private Vector2 moveDirection;

    private void Start()
    {
        CrouchSpeed = moveSpeed * CrouchMultiplier;
    }
    void Update() //processing inputs
    {
        ProcessInputs();

        if (Input.GetKey(KeyCode.LeftControl))
        {
            IsCrouching = true;
            playercollider.size = new Vector2(0.4f, 0.4f);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            IsCrouching = false;
            playercollider.size = new Vector2(1, 1);
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

}
