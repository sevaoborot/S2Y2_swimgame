using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrower : MonoBehaviour
{
    public float throwForce;
    public GameObject ballPrefab;
    public int maxBalls = 3;
    private int ballsThrown = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ballsThrown < maxBalls)
        {
            // Instantiate a new ball object
            GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);

            // Get the direction the player is aiming
            Ray aimRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 throwDirection = aimRay.direction;

            // Make sure the ball is thrown to the right (positive) Y direction
            if (throwDirection.y < 0)
            {
                throwDirection.y = 0;
            }

            // Apply the throw force in the desired direction to the ball GameObject
            Rigidbody ballRb = ball.GetComponent<Rigidbody>();
            ballRb.AddForce(throwDirection * throwForce, ForceMode.Impulse);

            // Increment the number of balls thrown and destroy the ball after a set amount of time
            ballsThrown++;
            Destroy(ball, 5f);
        }
    }
}
