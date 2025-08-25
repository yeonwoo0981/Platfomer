using System;
using UnityEngine;
using UnityEngine.U2D.Animation;


public class Collected : MonoBehaviour
{
   private Animator _animator;
   private bool _isCollected = false;
   private readonly int _collectedHash = Animator.StringToHash("Collected");
   public int score;
   public event Action _onCollected;
   
   [SerializeField] public FruitSO FruitSO;
   [SerializeField] public SpriteLibrary _spriteLibrary;
   
   private void Awake()
   {
      _animator = GetComponent<Animator>();
   }
   
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (_isCollected) return;
      
      if (other.TryGetComponent(out Player player))
      {
         _animator.SetTrigger(_collectedHash);
         Debug.Log(FruitSO.name + " collected!");
         _onCollected?.Invoke();
         _isCollected = true;
      }
   }

   public void DestroyCollected()
   {
      Destroy(gameObject);
   }

   public void OnValidate()
   {
      if (FruitSO == null) return;
      
      gameObject.name  =  FruitSO.fruitName;
    
      if (_spriteLibrary != null) 
         _spriteLibrary.spriteLibraryAsset  = FruitSO.spriteAsset;
   }
}
