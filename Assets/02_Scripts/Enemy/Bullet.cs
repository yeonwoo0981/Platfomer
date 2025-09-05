using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Collider2D _col;
    [SerializeField] private float _speed = 5f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<Collider2D>();
    }

    public void Fire(Vector2 direction, float lifeTime)
    {
        _rb.linearVelocity = direction * _speed;
        StartCoroutine(LifeTimeCoroutine(lifeTime));
    }
    
    private IEnumerator LifeTimeCoroutine(float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
