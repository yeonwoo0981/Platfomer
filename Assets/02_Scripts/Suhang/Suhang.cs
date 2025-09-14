using System;
using UnityEngine;

public class Suhang : MonoBehaviour
{
   public float chaseRadius;
   public float attackRadius;
   public LayerMask playerMask;
   
   public PlayerMovement moveCompo { get; private set; }
   public Animator animCompo { get; private set; }
   
   public Transform target;
   private Transform _visTrm;

   private void Awake()
   {
      moveCompo = GetComponent<PlayerMovement>();
      animCompo = GetComponentInChildren<Animator>();
      _visTrm = transform.Find("Virtus");
   }

   public void FlipX(float xMove)
   {
      if (xMove < 0)
      {
         _visTrm.eulerAngles = new Vector3(0, 180, 0);
      }
      else if (xMove > 0)
      {
         _visTrm.eulerAngles = new Vector3(0, 0, 0);
      }
   }

   public Collider2D CheckPlayerInChaseRange()
   {
      return Physics2D.OverlapCircle(transform.position, chaseRadius, playerMask);
   }
   
   public Collider2D CheckPlayerInAttackRange()
   {
      return Physics2D.OverlapCircle(transform.position, attackRadius, playerMask);
   }

   private void OnDrawGizmos()
   {
      Gizmos.color = Color.darkOrange;
      Gizmos.DrawWireSphere(transform.position, chaseRadius);
      Gizmos.color = Color.darkRed;
      Gizmos.DrawWireSphere(transform.position, attackRadius);
   }

   internal void CanAttack()
   {
      
   }
}
