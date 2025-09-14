using System;
using UnityEngine;

public class SuhangBrain : MonoBehaviour
{
    private SuhangStateMachine suhangStateMachine;
    private Suhang _suhang;

    [SerializeField] private LayerMask _playerMask;
    private float _chaseRange = 10f;
    private float _attackRange = 1.5f;

    private void Awake()
    {
        suhangStateMachine = new SuhangStateMachine(this);
        _suhang = GetComponent<Suhang>();
        suhangStateMachine.AddState(SuhangStateType.Idle, new SuhangIdleState(_suhang, suhangStateMachine, "SuhangIdle"));
        suhangStateMachine.AddState(SuhangStateType.Chase, new SuhangChaseState(_suhang, suhangStateMachine, "SuhangChase"));
        suhangStateMachine.AddState(SuhangStateType.Attack, new SuhangAttackState(_suhang, suhangStateMachine, "SuhangAttack"));
    }

    private void Start()
    {
        suhangStateMachine.initialized(SuhangStateType.Idle);
    }

    private void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, _attackRange, _playerMask))
        {
            UpdateState(SuhangStateType.Attack);
        }
        else if (Physics2D.OverlapCircle(transform.position, _chaseRange, _playerMask))
        {
            UpdateState(SuhangStateType.Chase);
        }
        else
        {
            UpdateState(SuhangStateType.Idle);
        }
    }

    private void UpdateState(SuhangStateType state)
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.darkOrange;
        Gizmos.DrawWireSphere(transform.position, _chaseRange);
        Gizmos.color = Color.darkRed;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }
}
