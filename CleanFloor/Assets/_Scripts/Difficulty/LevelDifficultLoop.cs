using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDifficultLoop
{
    public static LevelDifficulty GetCurrentLevelDifficulty(int levelNumber)
    {
        return LevelDifficulty.Easy;
    }
}

public enum LevelDifficulty
{
    Easy,
    Medium,
    Hard
}
