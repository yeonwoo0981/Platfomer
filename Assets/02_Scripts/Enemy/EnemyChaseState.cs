using UnityEngine;

public class EnemyChaseState : EnemyState
{
    public override void Enter()
    {
        base.Enter();
       // 애니메이션
    }
    
    public override void UpdateState()
    {
        // 플레이어를 향해 이동
        // 범위 밖으로 나가면 IdleState로 번경
        // 공격 범위 안에 있으면 AttackState로 변경
    }

    public override void Exit()
    {
        base.Exit();
    }
}
