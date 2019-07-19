using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
{
    public Level level;

    public Game()
    {
        int levelNumber = GetLastSavedLevel();
        level = new Level(levelNumber);

    }
    public void GoNextLevel()
    {

    }
    private int GetLastSavedLevel()
    {
        //TODO:get last saved level
        return 1;
    }
}
