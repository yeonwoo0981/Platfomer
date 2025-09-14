using System;
using UnityEngine;

public class SuhangChaseState : SuhangState
{
    public SuhangChaseState(Suhang suhang, SuhangStateMachine stateMachine, string animBoolName) : base(suhang, stateMachine, animBoolName)
    {
    }

    public override void EnterState()
    {
        // 추적 애니메이션
    }

    public override void UpdateState()
    {
        // 적을 쫓으며 공격 범위 내에 들어오면 공격 State로 변경
        Vector2 dir = _suhang.target.position - _suhang.transform.position;
        _suhang.moveCompo.SetXMove(MathF.Sign(dir.x));
        _suhang.FlipX(MathF.Sign(dir.x));

        if (!_suhang.CheckPlayerInChaseRange())
        {
            _stateMachine.ChangeState(SuhangStateType.Chase);
            return;
        }
        else if (!_suhang.CheckPlayerInAttackRange())
        {
            _stateMachine.ChangeState(SuhangStateType.Attack);
            return;
        }
    }

    public override void ExitState()
    {
        // 애니메이션 초기화
    }
}
