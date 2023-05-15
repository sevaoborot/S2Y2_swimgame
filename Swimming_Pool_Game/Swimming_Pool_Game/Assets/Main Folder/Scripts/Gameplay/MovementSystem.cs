using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    [SerializeField] Vector3 centreOfMap;
    [SerializeField] float rotationAngle;

    Vector2 centreDot;
    Vector2 InputDirection;
    CharacterController _char;
    bool isJumping = false;
    string movementType;

    private void Awake()
    {
        _char = GetComponent<CharacterController>();
        Debug.Log(transform.position.y);
        centreDot = new Vector2(centreOfMap.x, centreOfMap.z);
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

    private Vector2 FindVectorFromCentreToPos()
    {
        return new Vector2(transform.position.x - centreOfMap.x, transform.position.z - centreOfMap.z);
    }

    private float isOnARightSide (Vector2 A, Vector2 B, Vector2 C)  // AB - vector with A start dot, C - random dot in a plane
    {
        float D = (C.x - A.x) * (B.y - A.y) - (C.y - A.y) * (B.x - A.x);
        return D;
    }

    private void Movement()
    {
        if (InputDirection!=Vector2.zero)
        {
            switch (movementType) {
                case "CircleMovement":
                    float rotationSpeed = rotationAngle;
                    Vector2 pos2 = new Vector2(transform.position.x, transform.position.y); //current position in 2d
                    Vector2 positionVector = FindVectorFromCentreToPos();
                    float playerToInputAngle = Vector3.Angle(positionVector, InputDirection);
                    if (playerToInputAngle < rotationAngle) rotationSpeed = playerToInputAngle;
                    if (isOnARightSide(centreDot,pos2,InputDirection)<=0) rotationSpeed *= -1;
                    transform.RotateAround(centreOfMap, Vector3.up, rotationSpeed * Time.deltaTime);
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