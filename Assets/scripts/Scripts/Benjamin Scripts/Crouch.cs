using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
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
            playercollider.size = new Vector2(0.4f, 0.4f);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            IsCrouching = false;
            playercollider.size = new Vector2(1,1);
        }


       // rb.velocity = new Vector2(moveDirection.x * (IsCrouching ? CrouchSpeed : moveSpeed), moveDirection.y * (IsCrouching ? CrouchSpeed : moveSpeed));

       // inte säker om detta skulle fungera, men är menad att ändra movespeed till crouchspeed om IsCrouching är true
    }
}
