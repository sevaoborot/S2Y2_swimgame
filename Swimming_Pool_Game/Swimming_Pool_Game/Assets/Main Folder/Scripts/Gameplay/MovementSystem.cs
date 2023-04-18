using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [Header("MovementSettings")]
    [SerializeField] float angleSpeed;
    [SerializeField] Vector3 velocity;
    [SerializeField] float smoothTime;
    [SerializeField] float radius;
    [SerializeField] Vector3 centreOfPlaygroud;
    //[SerializeField] int playerIndex;

    float angleX;
    float angleY;
    Vector2 InputDirection;
    //Rigidbody _rb;
    CharacterController _char;
    bool isJumping = false;

    private void Awake()
    {
        //_rb = GetComponent<Rigidbody>();
        _char = GetComponent<CharacterController>();
        float angleX = Vector3.Angle(Vector3.right, transform.position);
        float angleY = Vector3.Angle(Vector3.back, transform.position);
        Debug.Log($"AngleX {angleX}, angleY {angleY}");
    }

    private void Update()
    {
        Movement();
        //_rb.AddForce(new Vector3(InputDirection.x, 0, InputDirection.y).normalized * speed, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") isJumping = false;
    }

    private void Movement()
    {
        if (InputDirection!=Vector2.zero)
        {
            //InputDirection = InputDirection.normalized;
            //transform.position = new Vector3(InputDirection.x, 0, InputDirection.y) * 3f;

            //SHOULD USE MOVEPOSITION i guess and  character controller
            //InputDirection = InputDirection.normalized;
            //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(InputDirection.x, transform.position.y, InputDirection.y) * radius, ref velocity, smoothTime);

            //not what i need to
            //InputDirection = InputDirection.normalized;
            //Vector3 newPos = Vector3.Slerp(transform.position - centreOfPlaygroud, new Vector3(InputDirection.x, transform.position.y, InputDirection.y)*radius - centreOfPlaygroud, angleSpeed) + centreOfPlaygroud; //it's working but overlaps
            //Vector3 newPos = new Vector3(InputDirection.x, transform.position.y, InputDirection.y) * radius;
            //Vector3 movementVector = newPos - transform.position;
            
            //Vector3 movingVector = Vector3.Slerp(transform.position - centreOfPlaygroud, new Vector3(InputDirection.x, transform.position.y, InputDirection.y) * radius - centreOfPlaygroud, 0.01f) + centreOfPlaygroud; 
            //_char.Move(movingVector * Time.deltaTime); not working properly, overlaps
            //_char.Move(movementVector * Time.deltaTime);
            
        }
    }

    /*
    public int GetIndex()
    {
        return playerIndex;
    }*/

    public void Jump()
    {
        if (!isJumping)
        {
            //_rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
        }
    }

    public void GetVector(Vector2 value)
    {
        InputDirection = value;
    }
}
