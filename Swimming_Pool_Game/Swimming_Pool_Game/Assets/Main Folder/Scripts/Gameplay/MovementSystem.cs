using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] float speed;
    [SerializeField] int playerIndex;

    Vector2 InputDirection;
    Rigidbody _rb;
    bool isJumping = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rb.AddForce(new Vector3(InputDirection.x, 0, InputDirection.y).normalized * speed, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") isJumping = false;
    }

    public int GetIndex()
    {
        return playerIndex;
    }

    public void Jump()
    {
        if (!isJumping)
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
        }
    }

    public void Movement(Vector2 value)
    {
        InputDirection = value;
    }
}
