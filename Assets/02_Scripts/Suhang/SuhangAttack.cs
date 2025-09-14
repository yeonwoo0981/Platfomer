using System;
using UnityEngine;

public class SuhangAttack : MonoBehaviour
{
    [SerializeField] private Sbullet _bullet;
    [SerializeField] private float _coolDown;
    private float _lastAttackTime;

    private Suhang _enemy;

    public bool AnimationEndTrigger = false;

    private void Awake()
    {
        _enemy = GetComponent<Suhang>();
    }

    private void Start()
    {
        _enemy.GetComponentInChildren<EnemyAnimator>().OnEndTrigger += () => AnimationEndTrigger = true;
    }

    public bool CanAttack()
    {
        return Time.time >= _lastAttackTime + _coolDown;
    }

    public void Attack()
    {
        _lastAttackTime = Time.time;
        
        Vector2 dir = _enemy.target.position - transform.position;
        
        var tree = Instantiate(_bullet, transform.position, Quaternion.identity);
        tree.TrowTree(new Vector2(dir.x, 0) * 4, 3f);
    }
}
