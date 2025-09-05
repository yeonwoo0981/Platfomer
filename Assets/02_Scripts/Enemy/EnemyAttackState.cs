using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(Enemy enemy, string animName, EnemyStateMachine stateMachine) : base(enemy, animName, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("공격람쥐");
        _enemy.MoveCompo.SetXMove(0f);
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
