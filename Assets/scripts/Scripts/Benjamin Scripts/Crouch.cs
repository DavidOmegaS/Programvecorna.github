using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    // DO NOT USE THIS SCRIPT
    // this script exists incase majas playermovement scripts crouch function doesnt work and i have to bugfix
    newPlayerMovement nPL;
    [SerializeField] BoxCollider2D playercollider;
    public float CrouchSpeed;
    [SerializeField] float CrouchMultiplier;
    public bool IsCrouching;
    // Start is called before the first frame update
    void Start()
    {
        nPL = GetComponent<newPlayerMovement>();
        CrouchSpeed = nPL.moveSpeed * CrouchMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            IsCrouching = true;
            playercollider.size = new Vector2(0.3f, 0.3f);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            IsCrouching = false;
            playercollider.size = new Vector2(1,1);
        }


       // rb.velocity = new Vector2(moveDirection.x * (IsCrouching ? CrouchSpeed : moveSpeed), moveDirection.y * (IsCrouching ? CrouchSpeed : moveSpeed));

       // inte s�ker om detta skulle fungera, men �r menad att �ndra movespeed till crouchspeed om IsCrouching �r true
    }
}