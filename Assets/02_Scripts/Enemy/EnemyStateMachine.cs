using System;
using UnityEngine;

    public enum EnemyStateType
    {
        Idle,
        Chase,
        Attack
    }
public class EnemyStateMachine : MonoBehaviour
{
    public void AddState(EnemyState state)
    {
        
    }
    private EnemyStateType _enemyStateType;

    private void Start()
    {
        _enemyStateType = EnemyStateType.Idle;
    }
}
