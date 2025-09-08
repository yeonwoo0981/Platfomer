using UnityEngine;

public class EnemyHitState : EnemyState
{
    private float _hitDuration = 0.5f; // 피격 상태 유지 시간
    private float _startTime;

    public EnemyHitState(Enemy enemy, string animName, EnemyStateMachine stateMachine) 
        : base(enemy, animName, stateMachine)
    {
    }
    
    public override void Enter()
    {
        base.Enter();
        _startTime = Time.time;
        Debug.Log("쳐맞은 다람쥐");
        _enemy.MoveCompo.SetXMove(0f); 
    }

    public override void UpdateState()
    {
        base.UpdateState();
        
        if (Time.time >= _startTime + _hitDuration)
        {
            if (_enemy.CheckChaseRange())
                _stateMachine.ChangeState(EnemyStateType.Chase);
            else
                _stateMachine.ChangeState(EnemyStateType.Idle);
        }
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Enemy Hit State 종료");
    }
}
