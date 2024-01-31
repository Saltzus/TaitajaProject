using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Vector2 turn;
    public float x;
    public float y;
    private Rigidbody rb;
    private float walkSpeed;
    public float forceConst = 1;
    private bool canJump = false;
    public float Raydist = 1;
    public float sprintSpeed = 10;
    public float originalWalkSpeed = 5f;


    private void Update()
    {
        turn.y += Input.GetAxis("Mouse Y");
        turn.x += Input.GetAxis("Mouse X");

        if (turn.y < -90) turn.y = -90;
        if (turn.y > 90) turn.y = 90;





        RaycastHit hit;
        Ray landingRay = new Ray(transform.position, Vector3.down);
        Debug.DrawRay(transform.position, Vector3.down * Raydist);
        if (Physics.Raycast(landingRay, out hit, Raydist))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (hit.collider == null)
                {
                    canJump = false;

                }
                else
                {
                    canJump = true;

                }

            }
            if (canJump)
            {
                canJump = false;
                rb.AddForce(0, forceConst, 0, ForceMode.Impulse);
            }


        }
    }

    private void FixedUpdate()
    {
      
        if (Input.GetKey(KeyCode.LeftShift))
        { 
            if (canJump)
            { 
                  walkSpeed = sprintSpeed;
            }
            
        }
        else
        {
            walkSpeed = originalWalkSpeed;
        }

        // Rotation
        Cursor.lockState = CursorLockMode.Locked;
        Camera.main.transform.localRotation = Quaternion.Euler(-turn.y, 0, 0);
        transform.localRotation = Quaternion.Euler(0, turn.x, 0);

        // Movement
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }

        Vector3 moveDirection = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(moveDirection.x * walkSpeed, rb.velocity.y , moveDirection.z * walkSpeed);
    }
}