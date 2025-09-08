using UnityEngine;

public class EnemyIdleState : EnemyState
{
    private float _checkTimer = 0.3f;
    private float _lastCheckTime;
    
    public EnemyIdleState(Enemy enemy, string animName, EnemyStateMachine stateMachine) : base(enemy, animName, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("다람쥐가만히");
        _enemy.MoveCompo.SetXMove(0f);
        _lastCheckTime = Time.time;
        // 감지 거리 내에서 플레이어를 찾지 못함
        // 이동을 하다가 정지
        // 애니메이션 실행
    }

    public override void UpdateState()
    {
        if (_enemy.IsHit())
        {
            _stateMachine.ChangeState(EnemyStateType.Hit);
            return;
        }
        
        // 0.3초마다 (구) 매 프레임마다 플레이어와 enemy 사이의 거리 측정
        if (_lastCheckTime + _checkTimer < Time.time)
        {
            if (_enemy.CheckChaseRange())
            {
                _stateMachine.ChangeState(EnemyStateType.Chase);
                return;
            }
            _lastCheckTime = Time.time;
        }
        // 플레이어가 추적 범위 안에 있으면 -> MoveState로 변경
    }

    public override void Exit()
    {
        base.Exit();
    }
}
