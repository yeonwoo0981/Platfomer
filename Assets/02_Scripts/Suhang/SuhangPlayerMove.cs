using System;
using UnityEngine;

public class SuhangPlayerMove : MonoBehaviour
{
    public Rigidbody2D _rbCompo { get; private set; }
    [SerializeField] private float _moveSpeed = 5f, _jumpPower = 7f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Vector2 _groundCheckSize;
    [SerializeField] private LayerMask _whatIsGround;

    [SerializeField] private float _extraGravity = 30f;
    [SerializeField] private float _gravityDelay = 0.5f;

    private float _timeInAir;
    private float _xMove;
    [field:SerializeField] public bool IsGrounded { get; private set; } 
    
    private void Awake()
    {
        _rbCompo = GetComponent<Rigidbody2D>();
    }

    public void SetXMove(float xMove)
    {
        _xMove = xMove;
    }

    private void Update()
    {
        CalculateAirTime();
    }

    private void CalculateAirTime()
    {
        if (!IsGrounded)
            _timeInAir += Time.deltaTime;
        else
            _timeInAir = 0;
    }

    private void ApplyExtraGravity()
    {
        if (_timeInAir >= _extraGravity)
        {
            _rbCompo.AddForce(Vector2.down * _extraGravity);
        }
    }

    private void FixedUpdate()
    {
        IsGrounded = CheckGround();
        HorizontalMove();
        ApplyExtraGravity();
    }

    private void HorizontalMove()
    {
        float xVelocity = _xMove * _moveSpeed;
        _rbCompo.linearVelocityX = xVelocity;
    }

    public void Jump()
    {
        _rbCompo.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
    }

    public bool CheckGround()
    {
        Collider2D collider = Physics2D.OverlapBox(_groundCheck.position, _groundCheckSize,0, _whatIsGround);
        return collider;
    }

    private void OnDrawGizmos()
    {
        if (_groundCheck == null) return;
        
        Gizmos.color = Color.goldenRod;
        Gizmos.DrawWireCube(_groundCheck.position, _groundCheckSize);
        Gizmos.color = Color.antiqueWhite;
    }
}
