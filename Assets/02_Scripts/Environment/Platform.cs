using System;
using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Player _onPlayer = null;
    
    private Collider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.TryGetComponent(out Player player))
                _onPlayer = player;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
            _onPlayer = null;
    }

    private void Update()
    {
        if (_onPlayer != null)
        {
            if (_onPlayer._playerInput.MoveDir.y < 0)
            {
                Physics2D.IgnoreCollision(_collider,_onPlayer._collider, true);
                StartCoroutine(ignoreCancleCoroutine(_onPlayer._collider));
            }
        }
    }

    private IEnumerator ignoreCancleCoroutine(Collider2D player)
    {
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreCollision(_collider, player, false);
    }
}
