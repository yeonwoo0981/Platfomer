using System;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    private EnemyStateMachine  _stateMachine;

    [SerializeField] private Vector2 _chaseRange; // 추적범위
    [SerializeField] private Vector2 _attackRange; // 공격범위
    [SerializeField] private LayerMask _playerMask;

    private Enemy _enemy;
    
    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _stateMachine = new EnemyStateMachine();
        
        _stateMachine.AddState(EnemyStateType.Idle, new EnemyIdleState(_enemy, "EnemyIdle", _stateMachine));
        _stateMachine.AddState(EnemyStateType.Chase, new EnemyChaseState(_enemy, "EnemyRun", _stateMachine));
        _stateMachine.AddState(EnemyStateType.Attack, new EnemyAttackState(_enemy, "EnemyAttack", _stateMachine));
    }

    private void Start()
    {
        _stateMachine.Initlalized(EnemyStateType.Idle);
    }

    public void Update()
    {
        _stateMachine._currentState.UpdateState();

        if (Physics2D.OverlapBox(transform.position, _attackRange, 0, _playerMask))
        {
            _stateMachine.ChangeState(EnemyStateType.Attack);
        }
        else if (Physics2D.OverlapBox(transform.position, _chaseRange, 0, _playerMask))
        {
            _stateMachine.ChangeState(EnemyStateType.Chase);
        }
        else
        {
            _stateMachine.ChangeState(EnemyStateType.Idle);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, _chaseRange);
        Gizmos.color = Color.darkRed;
        Gizmos.DrawWireCube(transform.position, _attackRange);
    }
}