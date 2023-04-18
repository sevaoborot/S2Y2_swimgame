using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenaltyAim : MonoBehaviour
{
    // Reference to the ball object
    public Rigidbody ball;

    // Declare a variable to store the throwing force
    public float throwingForce = 500f;

    // Declare a variable to track if the player is holding the ball
    private bool isHoldingBall = true;

    void Update()
    {
        // Check if the left mouse button is pressed down and the player is holding the ball
        if (Input.GetMouseButtonDown(0) && isHoldingBall)
        {
            // Calculate the throwing direction based on the position of the mouse and the ball's position
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f; // Set a distance of 10 units from the camera
            Vector3 throwingDirection = Camera.main.ScreenToWorldPoint(mousePos) - ball.transform.position;

            // Apply a force to the ball using Rigidbody.AddForce
            ball.AddForce(throwingDirection.normalized * throwingForce);

            // Set the isHoldingBall variable to false to indicate that the player is no longer holding the ball
            isHoldingBall = false;
        }

        // Check if the "E" key is pressed down and the player is not already holding the ball
        if (Input.GetKeyDown(KeyCode.E) && !isHoldingBall)
        {
            // Set the position and rotation of the ball to match the player's position and rotation
            ball.transform.position = transform.position;
            ball.transform.rotation = transform.rotation;

            // Set the velocity and angular velocity of the ball to zero
            ball.velocity = Vector3.zero;
            ball.angularVelocity = Vector3.zero;

            // Set the isHoldingBall variable to true to indicate that the player is now holding the ball
            isHoldingBall = true;
        }
    }
}
