using System;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    public Action OnAttackTrigger;
    public Action OnEndTrigger;

    public void AttackStart()
    {
        OnAttackTrigger?.Invoke();
    }
    
    public void AttackEnd()
    {
        OnEndTrigger?.Invoke();
    }
}
