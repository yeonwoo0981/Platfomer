using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerInput _playerInput { get; private set; }
    public PlayerMovement _playerMovement { get; private set; }
    
    public PlayerAnimator _playerAnimator { get; private set; }
    public Collider2D _collider { get; private set; }

    public Transform _visualTrm;

    public bool IsGrounded => _playerMovement.IsGrounded;
    
    public bool _canDoubleJump = false;
    public bool _canTrippleJump = false; 

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerMovement = GetComponent<PlayerMovement>();
        _collider = GetComponent<Collider2D>();
        _playerAnimator = GetComponentInChildren<PlayerAnimator>();
        _visualTrm = transform.Find("VirtuaR");
        _playerInput.OnJumpKeyPressed += HandleJumpKeyPress;
        
    }
    
    private void HandleJumpKeyPress()
    {
        if (IsGrounded)
        {
            _playerMovement.Jump();
        }
        else if (_canDoubleJump)
        {
            _playerMovement.Jump();
            _playerAnimator.SetDoubleJump(true);
            _canDoubleJump = false;
        }
        else if (_canTrippleJump)
        {
            _playerMovement.Jump();
            _canTrippleJump = false;
        }
    }

    private void FixedUpdate()
    {
        if (IsGrounded)
        {
            _canDoubleJump = true;
            _canTrippleJump = true;
        }
        
    }
    private void Update()
    {
        _playerMovement.SetXMove(_playerInput.MoveDir.x);
        FlipX(_playerInput.MoveDir.x);
    }

    private void FlipX(float moveX)
    {
        if (moveX < 0)  // 왼쪽을 바라본다면
        {
            _visualTrm.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else if (moveX > 0)
        {
            _visualTrm.eulerAngles = new Vector3(0f, 0f, 0f);
        }
    }
}
