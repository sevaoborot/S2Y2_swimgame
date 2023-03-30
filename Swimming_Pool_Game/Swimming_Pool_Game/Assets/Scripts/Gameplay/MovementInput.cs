using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using static UnityEngine.InputSystem.PlayerInput;

public class MovementInput : MonoBehaviour
{
    MovementSystem _mv;
    PlayerInput _pin;

    private void Awake()
    {
        //_mv = GetComponent<MovementSystem>();
        var moverAvailable = FindObjectsOfType<MovementSystem>();
        _pin = GetComponent<PlayerInput>();
        int index = _pin.playerIndex;
        Debug.Log(_pin.playerIndex);
        _mv = moverAvailable.FirstOrDefault(m => m.GetIndex() == index);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (/*context.performed &&*/ _mv != null) _mv.Movement(context.ReadValue<Vector2>());
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (/*context.performed &&*/ _mv != null) _mv.Jump();
    }
}
