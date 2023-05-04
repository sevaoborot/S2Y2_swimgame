using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    /*
    [SerializeField] float jumpForce;
    [Header("MovementSettings")]
    [SerializeField] float angleSpeed;
    [SerializeField] Vector3 velocity;
    [SerializeField] float smoothTime;
    [SerializeField] float radius;
    [SerializeField] Vector3 centreOfPlaygroud;
    //[SerializeField] int playerIndex;
    */
    Vector2 InputDirection;
    CharacterController _char;
    bool isJumping = false;
    string movementType;

    private void Awake()
    {
        _char = GetComponent<CharacterController>();
        Debug.Log(transform.position.y);
    }

    private void Update()
    {
        Movement();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") isJumping = false;
    }


    public void SetMovementType(string type)
    {
        movementType = type;
    }


    private void Movement()
    {
        if (InputDirection!=Vector2.zero)
        {
            switch (movementType) {
                case "CircleMovement":
                    Debug.Log("Circle movement");
                    break;
                default:
                    Debug.Log("Regular input");
                    break;
            }
        }
    }

    public void Sit()
    {
        Debug.Log("Player sit");
    }

    public void Jump()
    {
        if (!isJumping)
        {
            isJumping = true;
        }
    }

    public void GetVector(Vector2 value)
    {
        InputDirection = value;
    }
}
