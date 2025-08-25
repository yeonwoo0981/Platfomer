using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public Vector2 MoveDir { get; private set; }
    public event Action OnJumpKeyPressed;
    
    public void OnMove(InputValue value) => MoveDir = value.Get<Vector2>();
    public void OnJump() => OnJumpKeyPressed?.Invoke();
}
