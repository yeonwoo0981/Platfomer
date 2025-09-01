using UnityEngine;
using TMPro;

public class StageSetting : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _stageLabel;
   private int currentStage;
   
   private void OnEnable()
   {
      currentStage = CurrentStageManager.Load();
      UpdateUI();
   }

   public void OnClickOpenStage(int stageNumber)
   {
      currentStage = stageNumber;
      CurrentStageManager.Save(currentStage);
      UpdateUI();
   }

   public void OnClickReset()
   {
      CurrentStageManager.Reset();
      currentStage = 1; 
      UpdateUI();
   }

   private void UpdateUI()
   {
      _stageLabel.text = $"플레이 횟수: {currentStage}";
   }
}
