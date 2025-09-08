using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    public PlayerMovement MoveCompo { get; private set; }

    public Transform _target;
    
    public Transform _visualTrm;
    
    private EnemyHeadKick _headKick;
    
    public Animator AnimCompo;
    
    private HealthSystem _healthSystem;
    
    [SerializeField] private Vector2 _chaseRange; // 추적범위
    [SerializeField] private Vector2 _attackRange; // 공격범위
    [SerializeField] private LayerMask _playerMask;
    
    private void Awake()
    {
        _headKick = GetComponentInChildren<EnemyHeadKick>();
        _healthSystem = GetComponent<HealthSystem>();
        AnimCompo = GetComponentInChildren<Animator>();
        MoveCompo = GetComponent<PlayerMovement>();
        _visualTrm = transform.Find("Visual");
    }
    
    public void FlipX(float moveX)
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

    public bool CheckChaseRange()
    {
        return Physics2D.OverlapBox(transform.position, _chaseRange, 0, _playerMask);
    }
    
    public bool CheckAttackRange()
    {
        return Physics2D.OverlapBox(transform.position, _attackRange, 0, _playerMask);
    }

    public bool IsHit()
    {
        return _headKick.CheckHeadKickHit();
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, _chaseRange);
        Gizmos.color = Color.darkRed;
        Gizmos.DrawWireCube(transform.position, _attackRange);
    }
}
