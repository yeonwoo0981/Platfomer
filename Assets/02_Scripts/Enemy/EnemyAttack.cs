using System;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
   [SerializeField] private GameObject _bullet;
   public Transform _target;

   private EnemyAnimator _enemyAnimator;

   private void Awake()
   {
      _enemyAnimator = GetComponentInChildren<EnemyAnimator>();
   }

   private void Start()
   {
      _target =LevelManager.Instance.Player.transform;
      _enemyAnimator.OnAttackTrigger += Attack;
   }

   public void Attack()
   {
      var bullet = Instantiate(_bullet, transform.position, Quaternion.identity);
      Vector2 dir = _target.position - transform.position;
      bullet.GetComponent<Bullet>().Fire(dir.normalized, 1.5f);
   }
}
