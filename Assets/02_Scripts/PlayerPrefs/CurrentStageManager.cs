using UnityEngine;

public class CurrentStageManager : MonoBehaviour
{
    private const string Key = "CurrentStage";
    
    public static void Save(int stageNumber)
    {
        PlayerPrefs.SetInt(Key, stageNumber);
        PlayerPrefs.Save();
        Debug.Log("현재 설정 스테이지 저장: " + stageNumber);
    }

    public static int Load()
    {
        int stage = PlayerPrefs.GetInt(Key, 1);
        Debug.Log("불러온 현재 설정 스테이지: " + stage);
        return stage;
    }
    
    public static void Reset()
    {
        PlayerPrefs.DeleteKey(Key);
        Debug.Log("현재 설정 스테이지 리셋 완료");
    }
}
