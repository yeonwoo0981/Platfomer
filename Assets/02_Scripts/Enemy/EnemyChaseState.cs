using UnityEngine;

public class EnemyChaseState : EnemyState
{
    public EnemyChaseState(Enemy enemy, string animName, EnemyStateMachine stateMachine) : base(enemy, animName, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("다람쥐뛴다");
       // 애니메이션
    }
    
    public override void UpdateState()
    {
        if (_enemy.IsHit())
        {
            _stateMachine.ChangeState(EnemyStateType.Hit);
            return;
        }
        
        // 플레이어를 향해 이동
       Vector3 dir = _enemy._target.position - _enemy.transform.position;
       _enemy.FlipX(-dir.x);
       _enemy.MoveCompo.SetXMove(Mathf.Sign(dir.x)); // dir.x가 양수면 1, 음수면 -1, 0이면 0
        // 범위 밖으로 나가면 IdleState로 번경
        if (!_enemy.CheckChaseRange())
        {
            _stateMachine.ChangeState(EnemyStateType.Idle);
        }
        else if (_enemy.CheckAttackRange())
        {
            _stateMachine.ChangeState(EnemyStateType.Attack);
        }
        // 공격 범위 안에 있으면 AttackState로 변경
    }

    public override void Exit()
    {
        base.Exit();
    }
}
