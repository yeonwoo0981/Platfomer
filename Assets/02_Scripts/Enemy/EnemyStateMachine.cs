using System;
using System.Collections.Generic;
using UnityEngine;

    public enum EnemyStateType
    {
        Idle,
        Chase,
        Attack,
        Hit,
        Dead,
    }
public class EnemyStateMachine
{
    private Dictionary<EnemyStateType, EnemyState> _stateDictionary = new();
    public EnemyState _currentState { get; private set; }
    
    public void AddState(EnemyStateType type, EnemyState state)
    {
        _stateDictionary.Add(type, state);
    }

    public void Initlalized(EnemyStateType stateState)
    {
        _currentState = _stateDictionary[stateState];
        _currentState?.Enter();
    }
    public void ChangeState(EnemyStateType newState)
    {
        _currentState?.Exit();
        _currentState = _stateDictionary[newState];
        _currentState?.Enter();
    }
}
