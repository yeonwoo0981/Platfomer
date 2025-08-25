using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [field:SerializeField] public LevelListSO _levelList { get; private set; }
    [SerializeField] private int _startLevel = 1;

    private GameObject _currentLevel;
    
    private void Start()
    {
        LoadLevel(_startLevel);
    }

    private void LoadLevel(int level)
    {
        if (_levelList.list.Count < level)
        {
            Debug.LogError("실행할 레벨이 없다.");
            return;
        }

        if (_currentLevel != null)
        {
            Destroy(_currentLevel.gameObject);
        }
        _currentLevel = Instantiate(_levelList.list[level - 1].prefab, Vector3.zero, Quaternion.identity);
    }
}
