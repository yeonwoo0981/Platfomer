using System;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    private EnemyStateMachine  _stateMachine;

    private Enemy _enemy;
    
    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _stateMachine = new EnemyStateMachine();
        
        _stateMachine.AddState(EnemyStateType.Idle, new EnemyIdleState(_enemy, "EnemyIdle", _stateMachine));
        _stateMachine.AddState(EnemyStateType.Chase, new EnemyChaseState(_enemy, "EnemyRun", _stateMachine));
        _stateMachine.AddState(EnemyStateType.Attack, new EnemyAttackState(_enemy, "EnemyAttack", _stateMachine));
        _stateMachine.AddState(EnemyStateType.Hit, new EnemyHitState(_enemy, "EnemyHit", _stateMachine));
        _stateMachine.AddState(EnemyStateType.Dead, new EnemyDeadState(_enemy,"EnemyIdle", _stateMachine));
    }

    private void Start()
    {
        _stateMachine.Initlalized(EnemyStateType.Idle);
    }

    public void Update()
    {
        _stateMachine._currentState.UpdateState();
    }
}