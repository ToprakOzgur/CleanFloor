using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public event Action<int> onProgressChangedEvent = delegate { };
    public event Action onLevelComplated = delegate { };
    public int levelNumber;

    public int underObjectsDustCount = 0;
    public int dustCount = 0;
    private int cleanedDustCount = 0;
    private int progress = 0;
    public Level(int levelNumber)
    {
        this.levelNumber = levelNumber;
    }
    public int CleanedDustCount
    {
        get
        {
            return cleanedDustCount;
        }
        set
        {
            cleanedDustCount = value;

            progress = Mathf.FloorToInt((100 - (float)(dustCount - underObjectsDustCount - cleanedDustCount) / (float)(dustCount - underObjectsDustCount) * 100));
            onProgressChangedEvent(progress);
            if (progress == 100)
            {
                onLevelComplated();
            }

        }
    }

}




