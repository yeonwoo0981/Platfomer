using UnityEngine;

public class EnemyAttackState : EnemyState
{
    private EnemyAttack _enemyAttack;
    public EnemyAttackState(Enemy enemy, string animName, EnemyStateMachine stateMachine) : base(enemy, animName, stateMachine)
    {
        _enemyAttack = enemy.GetComponent<EnemyAttack>();
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("공격람쥐");
        _enemy.MoveCompo.SetXMove(0f);
        _enemyAttack._isAnimationEnd = false;
        // 애니메이션
    }
    
    public override void UpdateState()
    {
        if (_enemy.IsHit())
        {
            _stateMachine.ChangeState(EnemyStateType.Hit);
            return;
        }
        
        // 공격이 다 끝나면
        if (_enemyAttack._isAnimationEnd)
        {
           _stateMachine.ChangeState(EnemyStateType.Chase);
        }
        // 공격 범위 밖으로 나가면 ChaseState로 번경
        // 감지 범위 밖에 있으면 IdleState로 변경
        // 공격 범위 내에 있을 시 공격
    }

    public override void Exit()
    {
        base.Exit();
    }
}
