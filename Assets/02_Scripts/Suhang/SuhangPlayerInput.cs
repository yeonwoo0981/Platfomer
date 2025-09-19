using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class SuhangPlayerInput : MonoBehaviour
{
    public Vector2 _moveDir { get; private set; }
    public Action _onJumpAction;

    private void Awake(InputValue value)
    {
        _moveDir = value.Get<Vector2>();
    }

    public void OnJump()
    {
        _onJumpAction?.Invoke();
    }
}
