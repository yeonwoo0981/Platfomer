using System;
using UnityEngine;

public abstract class EnemyState
{
    public virtual void Enter()
    {
        // 상태 진입 행동
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
