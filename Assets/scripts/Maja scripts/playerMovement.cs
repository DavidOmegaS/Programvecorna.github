using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;//så jag kan använda input systemet

public class playerMovement : MonoBehaviour //script används inte, input movement system som inte fungerade på andras datorer men den funkade på min :,)
{
    private Vector2 moveInput;
    private Rigidbody2D rb;
    public float moveSpeed = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();//rigidbody blir gameobject så man kan använda det i scriptet
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime); //FLYTTAR PÅ SIG på vector 2 aka x och y
    }

    /*void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>(); //vector 2 till gameobject
    }*/
}
