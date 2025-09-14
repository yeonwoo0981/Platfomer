using System.Collections.Generic;
using UnityEngine;

public enum SuhangStateType
{
    Idle,
    Chase,
    Attack
}

public class SuhangStateMachine : MonoBehaviour
{
    private Dictionary<SuhangStateType, SuhangState> _states = new();
    
    public SuhangState currentState;
    private SuhangBrain _enemy;

    public SuhangStateMachine(SuhangBrain brain)
    {
        _enemy = brain;
    }

    public void AddState(SuhangStateType stateType, SuhangState state)
    {
        _states.Add(stateType, state);
    }

    public void initialized(SuhangStateType stateType)
    {
        currentState = _states[stateType];
    }

    public void ChangeState(SuhangStateType stateType)
    {
        if (currentState != null)
        {
            currentState.ExitState();
        }
        currentState = _states[stateType];
        if (currentState != null)
        {
            currentState.EnterState();
        }
    }
}
