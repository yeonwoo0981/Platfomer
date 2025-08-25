using System;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float _speed = 6f;
    [SerializeField] private float _jumpPower = 7f;
    
    [Header("Ground Checker Settings")]
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private Vector2 _groundCheckerSize;
    [SerializeField] private LayerMask _whatIsGround;
    
    [Header("Extra Settings")]
    [SerializeField] private float _extraGravity = 30f;
    [SerializeField] private float _gravityDelay = 0.15f;
    
    [field: SerializeField] public bool IsGrounded { get; private set; }
    public Rigidbody2D _rb { get; private set; }
    
    private float timeInAir;
    private float _xMove;
    private float _timeInAir;

    private void Awake() => _rb = GetComponent<Rigidbody2D>();

    private void FixedUpdate()
    {
        IsGrounded = CheckGround();
        HorizontalMove();
        ApplyGravity();
    }

    private void HorizontalMove()
    {
        _rb.linearVelocity = new Vector2(_xMove * _speed, _rb.linearVelocity.y);
    }
    
    public void Jump()
    {
            _rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
    }

    private void Update()
    {
       CalculateTimeInAir();
    }

    private void CalculateTimeInAir()
    {
        if (!IsGrounded)
        {
            _timeInAir += Time.deltaTime;
        }
        else
        {
            _timeInAir = 0f; 
        }
    }

    public void SetXMove(float xMove) => _xMove = xMove;

    public bool CheckGround()
    {
        return Physics2D.OverlapBox(_groundChecker.position, _groundCheckerSize, 0, _whatIsGround);
    }

    private void OnDrawGizmos()
    {
        if (_groundChecker == null) return;
        
        Gizmos.color = Color.hotPink;
        Gizmos.DrawWireCube(_groundChecker.position, _groundCheckerSize);
        Gizmos.color = Color.white;
    }

    private void ApplyGravity()
    {
        if(_timeInAir > _gravityDelay)
        {
            _rb.AddForceY(-_extraGravity);
        }
        else
        {
            _timeInAir += Time.fixedDeltaTime;
        }
    }
}
    
    
