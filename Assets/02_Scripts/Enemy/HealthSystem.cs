using DG.Tweening;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [field:SerializeField] public int Health { get; private set; }
    [SerializeField] private int _maxHealth;
    private bool _isDead;

    private SpriteRenderer _sr;

    private void Awake()
    {
        _sr = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        Health = _maxHealth;
    }
    
    public void TakeDamage(int damage)
    {
        Health -= damage;
        Health = Mathf.Clamp(Health, 0, _maxHealth);
        
        if(Health <= 0)
        {
            if (_sr != null)
            {
                _sr.DOFade(0f, 0.5f)
                    .OnComplete(() =>
                    {
                        Destroy(gameObject);
                    });
            }
            else
            {
                Destroy(gameObject);
            }
            Debug.Log("죽음");
            _isDead= true;
        }
    }
}
