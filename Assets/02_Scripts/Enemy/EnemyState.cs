using System;
using UnityEngine;

public abstract class EnemyState
{
    protected Enemy _enemy;
    
    public EnemyState(Enemy enemy)
    {
        _enemy = enemy;
    }
    
    public virtual void Enter()
    {
        // 상태 진입 행동
        Debug.Log("다람쥐");
    }
    
    public virtual void UpdateState()
    {
        // 매 프레임 상태 로직
    }
    
    public virtual void Exit()
    {
        // 상태 
    }
}
