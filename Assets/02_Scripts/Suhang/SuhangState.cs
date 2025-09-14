using UnityEngine;

public abstract class SuhangState : MonoBehaviour
{
   protected Suhang _suhang;
   protected int _animBoolHash;
   protected bool _endTriggerCalled;
   protected SuhangStateMachine _stateMachine;

   public SuhangState(Suhang suhang, SuhangStateMachine stateMachine, string animBoolName)
   {
      _suhang = suhang;
      _stateMachine = stateMachine;
      _animBoolHash = Animator.StringToHash(animBoolName);
   }
   
   public virtual void EnterState()
   {
      
   }

   public virtual void UpdateState()
   {
      
   }

   public virtual void ExitState()
   {
      
   }
}
