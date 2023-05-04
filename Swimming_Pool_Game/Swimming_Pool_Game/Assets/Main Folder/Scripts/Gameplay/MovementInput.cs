using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using static UnityEngine.InputSystem.PlayerInput;

public class MovementInput : MonoBehaviour
{
    [SerializeField] MeshRenderer color;

    MovementSystem _mv;
    PlayerConfiguration playerConfig;
    PlayerControls controlls;

    private void Awake()
    {
        //_mv = GetComponent<MovementSystem>();
        _mv = GetComponent<MovementSystem>();
        controlls = new PlayerControls();
    }

    public void InitializePlayer(PlayerConfiguration pcm)
    {
        playerConfig = pcm;
        color.material = pcm.playerMaterial;
        playerConfig.playerInput.onActionTriggered += PlayerInput_onActionTriggered;
    }

    private void PlayerInput_onActionTriggered(InputAction.CallbackContext context)
    {
        if (context.action.name == controlls.Player.Movement.name) OnMove(context);
        if (context.action.name == controlls.Player.Jump.name) OnJump(context);
        if (context.action.name == controlls.Player.Sit.name) OnSit(context);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (_mv != null) _mv.GetVector(context.ReadValue<Vector2>());
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (_mv != null) _mv.Jump();
    }

    public void OnSit(InputAction.CallbackContext context)
    {
        if (_mv != null) _mv.Sit();
    }
}
