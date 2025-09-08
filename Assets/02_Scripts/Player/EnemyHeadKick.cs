using System;
using UnityEngine;

public class EnemyHeadKick : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private Vector2 headZoneSize;
    [SerializeField] private LayerMask playerMask;

    private HealthSystem _enemyHealth;

    private void Awake()
    {
        _enemyHealth = GetComponentInParent<HealthSystem>();
    }

    public bool CheckHeadKickHit()
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position, headZoneSize, 0f, playerMask);
        if (hit != null)
        {
            _enemyHealth.TakeDamage(damage);
            Debug.Log("공격람쥐");
            return true;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, headZoneSize);
    }
}
