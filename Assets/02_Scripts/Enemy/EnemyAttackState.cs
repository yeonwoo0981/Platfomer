using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public override void Enter()
    {
        base.Enter();
        Debug.Log("공격람쥐");
        // 애니메이션
    }
    
    public override void UpdateState()
    {
        // 공격 범위 밖으로 나가면 ChaseState로 번경
        // 감지 범위 밖에 있으면 IdleState로 변경
        // 공격 범위 내에 있을 시 공격
    }

    public override void Exit()
    {
        base.Exit();
    }
}
