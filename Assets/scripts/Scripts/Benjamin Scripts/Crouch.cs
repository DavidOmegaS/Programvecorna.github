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
        if (Input.GetKey(KeyCode.LeftControl)) // hold LeftControl to stealth
        {
            IsCrouching = true;
            playercollider.size = new Vector2(0.3f, 0.3f); // collider becomes smaller to get dectected in a lesser area
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl)) // release LeftControl
        {
            IsCrouching = false;
            playercollider.size = new Vector2(1,1); // collider becomes normal
        }


       // rb.velocity = new Vector2(moveDirection.x * (IsCrouching ? CrouchSpeed : moveSpeed), moveDirection.y * (IsCrouching ? CrouchSpeed : moveSpeed)); (if holding Crouchbutton uses crouchspeed instead of normal speed)
       // works in movement script, only here for reading purposes
    }
}
