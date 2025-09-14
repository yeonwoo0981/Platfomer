using System;
using UnityEngine;

public class Sbullet : MonoBehaviour
{
   private Rigidbody2D _rb;
   private float _lifeTime;

   private void Awake()
   {
      _rb = GetComponent<Rigidbody2D>();
   }

   public void TrowTree(Vector2 velocity, float lifeTime)
   {
      _lifeTime = lifeTime;
      _rb.AddForce(velocity, ForceMode2D.Impulse);
   }

   private void Update()
   {
      _lifeTime -= Time.deltaTime;
      if (_lifeTime <= 0)
      {
         Destroy(gameObject);
      }
   }
}
