using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;//s� jag kan anv�nda input systemet

public class playerMovement : MonoBehaviour //script anv�nds inte, input movement system som inte fungerade p� andras datorer men den funkade p� min :,)
{
    private Vector2 moveInput;
    private Rigidbody2D rb;
    public float moveSpeed = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();//rigidbody blir gameobject s� man kan anv�nda det i scriptet
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime); //FLYTTAR P� SIG p� vector 2 aka x och y
    }

    /*void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>(); //vector 2 till gameobject
    }*/
}
