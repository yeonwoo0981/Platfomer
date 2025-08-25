using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelListSO", menuName = "SO/LevelListSO")]
public class LevelListSO : ScriptableObject
{
    public List<LevelSO> list;

    public void OnValidate()
    {
        if (list == null) return;
        foreach (LevelSO level in list)
        {
            if (level ==null) return;
            level._levelNum = list.IndexOf(level) + 1;
        }
        
    }
}
