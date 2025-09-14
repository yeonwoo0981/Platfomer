using UnityEngine;

public class SuhangIdleState : SuhangState
{
    private readonly float _checkTimer;
    private float _lastCheckTime;
    
    public SuhangIdleState(Suhang suhang, SuhangStateMachine stateMachine, string animBoolName) : base(suhang, stateMachine, animBoolName)
    {
    }

    public override void EnterState()
    {
        // 추적 범위내에 적이 없으면 애니메이션
        _suhang.moveCompo.SetXMove(0f);
        _lastCheckTime = Time.time;
    }

    public override void UpdateState()
    {
        // 추적거리 확인 및 추적거리 내에 있으면 Chase로 변경
        if (_lastCheckTime + _checkTimer < Time.time)
        {
            _lastCheckTime = Time.time;
            if (_suhang.CheckPlayerInChaseRange())
            {
                _stateMachine.ChangeState(SuhangStateType.Chase);
                return;
            }
        }
    }

    public override void ExitState()
    {
        // 애니메이션 초기화
    }
}
