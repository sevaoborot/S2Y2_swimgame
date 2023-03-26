using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementSystem : MonoBehaviour
{
    //PARAMS
    [SerializeField] float jumpForce;
    [SerializeField] float speed;

    //CACHE
    PlayerInput _playerInput;
    PlayerControls _playerControls;
    Rigidbody _rb;
    bool isJumping = false;

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _rb = GetComponent<Rigidbody>();
        _playerInput = GetComponent<PlayerInput>();
        _playerControls.Player.Enable();
        _playerControls.Player.Jump.performed += Jump;
    }

    private void Update()
    {
        //TO DO: find a way how to make lines below in a separate func for movement
        Vector2 direction = _playerControls.Player.Movement.ReadValue<Vector2>();
        _rb.AddForce(new Vector3(direction.x, 0, direction.y).normalized * speed, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") isJumping = false;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && !isJumping)
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
        }
    }

    public void Movement(InputAction.CallbackContext context)
    {

    }
}
