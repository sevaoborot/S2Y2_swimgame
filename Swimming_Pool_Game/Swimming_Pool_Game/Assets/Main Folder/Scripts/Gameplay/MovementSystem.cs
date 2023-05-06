using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    [SerializeField] Vector3 centreOfMap;
    [SerializeField] float rotationAngle;

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

    private float CountAngleBetweenVectors()
    {
        Vector2 playerVector = new Vector2(transform.position.x - centreOfMap.x, transform.position.z - centreOfMap.z);
        float angleCos = (playerVector.x * InputDirection.x + playerVector.y * InputDirection.y) / (Mathf.Sqrt(Mathf.Pow(playerVector.x, 2) + Mathf.Pow(playerVector.y, 2)) * Mathf.Sqrt(Mathf.Pow(InputDirection.x, 2) + Mathf.Pow(InputDirection.y, 2)));
        float angle = Mathf.Acos(angleCos) * Mathf.Rad2Deg;
        return angle;
    }

    private void Movement()
    {
        if (InputDirection!=Vector2.zero)
        {
            switch (movementType) {
                case "CircleMovement":
                    float rotationSpeed;
                    float playerToInputAngle = CountAngleBetweenVectors();
                    if (playerToInputAngle < rotationAngle) rotationSpeed = playerToInputAngle * InputDirection.normalized.y;
                    else rotationSpeed = rotationAngle * InputDirection.normalized.y;
                    transform.RotateAround(centreOfMap, Vector3.up, rotationSpeed*Time.deltaTime);
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