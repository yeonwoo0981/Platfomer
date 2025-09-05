using UnityEngine;

public class EnemyIdleState : EnemyState
{
    public EnemyIdleState(Enemy enemy) : base(enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("다람쥐가만히");
        _enemy.MoveCompo.SetXMove(0f);
        // 감지 거리 내에서 플레이어를 찾지 못함
        // 이동을 하다가 정지
        // 애니메이션 실행
    }

    public override void UpdateState()
    {
        // 플레이어와 enemy 사이의 거리 측정
        // 플레이어가 추적 범위 안에 있으면 -> MoveState로 변경
    }

    public override void Exit()
    {
        base.Exit();
    }
}
