using System;
using UnityEngine;

public class SuhangAttackState : SuhangState
{
    private SuhangAttack _atkCompo;
    private Suhang _suhang;
    public SuhangAttackState(Suhang suhang, SuhangStateMachine stateMachine, string animBoolName) : base(suhang, stateMachine, animBoolName)
    {
        _suhang = suhang;
        _atkCompo = suhang.GetComponent<SuhangAttack>();
    }

    public override void EnterState()
    {
        // 공격 애니메이션
        FacingToPlayer();
        _suhang.moveCompo.SetXMove(0f);

        _atkCompo.AnimationEndTrigger = false;

        if (_atkCompo.CanAttack())
        {
            _atkCompo.Attack();
        }
    }


    public override void UpdateState()
    {
        // 공격 시도
        // 공격하고 나서 거리 확인
        // 멀어지면 다시 추적
        // 공격거리면 다시 공격
        if (_atkCompo.AnimationEndTrigger)
        {
            if (!_suhang.CheckPlayerInAttackRange())
            {
                _stateMachine.ChangeState(SuhangStateType.Idle);
                return;
            }
            else
            {
                if (_atkCompo.CanAttack())
                {
                    FacingToPlayer();
                    _atkCompo.Attack();
                }
            }
        }
    }

    public override void ExitState()
    {
        // 애니메이션 종료
    }
    private void FacingToPlayer()
    {
        float xDir = _suhang.target.position.x - _suhang.transform.position.x;
        _suhang.FlipX(MathF.Sign(xDir));
    }
}
