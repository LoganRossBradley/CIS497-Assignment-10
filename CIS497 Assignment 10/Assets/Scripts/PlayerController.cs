/* * Logan Ross 
 * * ScoreManager.cs 
 * * Assignment 10
 * * Lets the player jump and checks to see if the player hits an obstacle
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRB;
    public float jumpSpeed = 10;
    public CapsuleCollider playerCapsule;
    public GameManager gm;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            playerRB.velocity = new Vector3(0, jumpSpeed, 0);
        }
    }

    private bool IsGrounded()
    {
       return Physics.Raycast(playerCapsule.bounds.center, Vector3.down, playerCapsule.bounds.extents.y+0.01f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            gm.gameOver = true;
        }
    }
}
