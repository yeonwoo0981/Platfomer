using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private Player _player;
    
    private readonly int _velocityXhash = Animator.StringToHash("VelocityX");
    private readonly int _velocityYhash = Animator.StringToHash("VelocityY");
    private readonly int _isGroundHash = Animator.StringToHash("IsGround");
    private readonly int _doubleJumpHash = Animator.StringToHash("DoubleJump");

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponentInParent<Player>();
    }
    
    private void FixedUpdate()
    {
       Animation(_player._playerMovement);
    }

    private void Animation(PlayerMovement playerMovement)
    {
        _animator.SetFloat(_velocityXhash, math.abs(_player._playerMovement._rb.linearVelocityX));
        _animator.SetFloat(_velocityYhash, _player._playerMovement._rb.linearVelocityY);
        _animator.SetBool(_isGroundHash, _player.IsGrounded);
        
        if (playerMovement.IsGrounded)
            SetDoubleJump(false);
    }

    public void SetDoubleJump(bool value)
    {
        _animator.SetBool(_doubleJumpHash, value);
    }

    public void DoubleJumpEnd()
    {
        _animator.SetBool(_doubleJumpHash, false);
    }
}
