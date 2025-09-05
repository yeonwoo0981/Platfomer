using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [field:SerializeField] public LevelListSO _levelList { get; private set; }
    [SerializeField] private int _startLevel = 1;
    
    [field:SerializeField] public Player Player { get; private set; }

    private int _currentLevelNum = 0;
    private GameObject _currentLevel;
    
    public static LevelManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        _currentLevelNum = CurrentStageManager.Load();
        LoadLevel(_currentLevelNum);
    }

    private void LoadLevel(int level)
    {
        if (_levelList.list.Count < level)
        {
            Debug.LogError("실행할 레벨이 없다.");
            return;
        }

        _currentLevelNum = level;
        CurrentStageManager.Save(_currentLevelNum);
        
        if (_currentLevel != null)
        {
            Destroy(_currentLevel.gameObject);
        }
        _currentLevel = Instantiate(_levelList.list[level - 1].prefab, Vector3.zero, Quaternion.identity);
        _currentLevel.GetComponent<Level>().SetUpLevel(Player);
    }
    
    public void LoadNextLevel()
    {
        int nextLevelNum = _currentLevelNum + 1;

        if (nextLevelNum > _levelList.list.Count)
        {
            Debug.Log("클리어");
            SceneManager.LoadScene(0);
        }
        else {
            LoadLevel(nextLevelNum);
        }
    }
}
