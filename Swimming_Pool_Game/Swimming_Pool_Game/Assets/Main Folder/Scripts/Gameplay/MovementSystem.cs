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

    //float angleX;
    //float angleZ;
    Vector2 InputDirection;
    //Rigidbody _rb;
    CharacterController _char;
    bool isJumping = false;

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

    private void Movement()
    {
        if (InputDirection!=Vector2.zero)
        {
            Debug.Log("Movement1 is using");
        }
    }

    /*
    public int GetIndex()
    {
        return playerIndex;
    }*/

    public void Sit()
    {
        Debug.Log("Player sit");
    }

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
