using UnityEngine;

public class EnemyHitState : EnemyState
{
    private float _checkTimer = 0.5f;
    private float _lastCheckTime;

    public EnemyHitState(Enemy enemy, string animName, EnemyStateMachine stateMachine) 
        : base(enemy, animName, stateMachine)
    {
    }
    
    public override void Enter()
    {
        base.Enter();
        _lastCheckTime = Time.time;
        Debug.Log("쳐맞은 다람쥐");
        _enemy.MoveCompo.SetXMove(0f); 
    }

    public override void UpdateState()
    {
        base.UpdateState();
        
        if (Time.time >= _lastCheckTime + _checkTimer)
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
    }
}
