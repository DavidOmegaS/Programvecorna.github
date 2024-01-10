using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class topdownMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 moveInput;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
