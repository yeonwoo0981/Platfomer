using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private Animator _animator;
    private PlayerInput _playerInput;
    
    private readonly int _velocityXHash = Animator.StringToHash("inputX");
    private readonly int _velocityYHash = Animator.StringToHash("inputY");

    private Vector2 _lastMoveDir;
    private bool _isMoving;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerInput = GetComponentInParent<PlayerInput>();
    }

    // 복습해볼겸 트리플 점프 애니메이션 제작
    private void Update()
    {
        if (_playerInput.MoveDir.x != 0 || _playerInput.MoveDir.y != 0)
        {
            _lastMoveDir = _playerInput.MoveDir;
            _isMoving = true;
            _animator.SetFloat(_velocityXHash, _playerInput.MoveDir.x);
            _animator.SetFloat(_velocityYHash, _playerInput.MoveDir.y);
            _animator.speed = 1f;
        }
        else
        {
            _lastMoveDir = _playerInput.MoveDir;
            _isMoving = false;
            _animator.speed = 0f;
        }
    }
    
    
}
