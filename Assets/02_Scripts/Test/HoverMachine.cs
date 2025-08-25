using System;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class HoverMachine : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform _rectTransform;
    private Tween _hoverTween;

    public float _angle = 10f;
    public float _duration = 0.5f;

    private void Awake() => _rectTransform = GetComponent<RectTransform>();
    
    public void OnPointerEnter(PointerEventData eventData)
    {
            _hoverTween = _rectTransform
            .DORotate(new Vector3(0, 0, _angle), _duration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo); 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_hoverTween != null && _hoverTween.IsActive())
            _hoverTween.Kill();
        
        _rectTransform.DORotate(Vector3.zero, 0.3f).SetEase(Ease.OutSine);
    }
}
