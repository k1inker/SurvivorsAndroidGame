using System;
using UnityEngine;

public class PlayerLevelManager : MonoBehaviour
{
    [SerializeField] private int _maxValuePerLevel;
    [SerializeField] private sbyte _multiplayLevel = 2;
    private int _currentValueOnLevel = 0;

    public Action<int> OnExperienceChange;
    public Action<int> OnLevelUp;
    private void Start()
    {
        OnExperienceChange += LevelUp;

        OnExperienceChange?.Invoke(_currentValueOnLevel);
        OnLevelUp?.Invoke(_maxValuePerLevel);
    }
    public void IncreaseExperienceValue(int value)
    {
        _currentValueOnLevel += value;
        OnExperienceChange?.Invoke(_currentValueOnLevel);
    }
    public void LevelUp(int currentValue)
    {
        if(currentValue < _maxValuePerLevel)
        {
            return;
        }

        int expToNextLevel = currentValue - _maxValuePerLevel;
        _currentValueOnLevel = 0;
        _maxValuePerLevel *= _multiplayLevel;
        OnLevelUp?.Invoke(_maxValuePerLevel);
        IncreaseExperienceValue(expToNextLevel);
    }
}
