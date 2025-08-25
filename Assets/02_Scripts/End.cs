using System;
using DG.Tweening;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class End : MonoBehaviour
{
    public enum EndState
    {
        Invisible,
        Visible
        
        // FSM때 추가할 예정
    }
    
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Vector3 _dropOffset;
    private CinemachineImpulseSource _impulseSource;
    private EndState _state;
    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _impulseSource = GetComponent<CinemachineImpulseSource>();
        _state = EndState.Invisible;
        
        _spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
    }

    // 람다식은 웬만해선 한 줄 코드에서만 사용할 것
    public void Show()
    {
        Vector3 dropPos = transform.position;
            
        transform.Translate(_dropOffset);
            
        Sequence seq = DOTween.Sequence();
        seq.Append(_spriteRenderer.DOFade(1f, 3f));
        seq.Append(transform.DOMove(dropPos, 0.5f).SetEase(Ease.InQuart));
        seq.AppendCallback(() => _impulseSource.GenerateImpulse());
        
        _state = EndState.Visible;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _state == EndState.Visible)
        {
            SceneManager.LoadScene(1);
        }
    }
}
