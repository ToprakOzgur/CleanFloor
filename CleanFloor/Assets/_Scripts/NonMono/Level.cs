using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public static event Action<int> OnProgressChangedEvent = delegate { };
    public static event Action<float> OnDemagedEvent = delegate { };
    public static event Action OnLevelComplated = delegate { };
    public int levelNumber;
    public int underObjectsDustCount = 0;
    public int dustCount = 0;
    private int cleanedDustCount = 0;
    private int progress = 0;
    private float touchTime = 0;
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
            OnProgressChangedEvent(progress);
            if (progress == 100)
            {
                OnLevelComplated();
            }

        }
    }



    public float TouchTime
    {
        get
        {
            return touchTime;
        }
        set
        {
            touchTime = value;
            OnDemagedEvent(touchTime);

        }
    }
}




