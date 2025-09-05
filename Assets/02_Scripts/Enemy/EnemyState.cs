using System;
using UnityEngine;

public abstract class EnemyState
{
    protected Enemy _enemy;
    protected EnemyStateMachine _stateMachine;
    protected int _animHash;
    public EnemyState(Enemy enemy, string animName, EnemyStateMachine stateMachine)
    {
        _enemy = enemy;
        _stateMachine = stateMachine;
        _animHash = Animator.StringToHash(animName);
    }
    
    public virtual void Enter()
    {
        // 상태 진입 행동
        _enemy.AnimCompo.SetBool(_animHash, true);
    }
    
    public virtual void UpdateState()
    {
        // 매 프레임 상태 로직
    }
    
    public virtual void Exit()
    {
        // 상태
        _enemy.AnimCompo.SetBool(_animHash, false);
    }
}
