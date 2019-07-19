using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public int levelNumber;
    private RoomGenerator roomGenerator;

    private LevelParameters parameters;
    public Level(int levelNumber)
    {
        this.levelNumber = levelNumber;

        setUpLevel();
    }

    private void setUpLevel()
    {
        var diff = LevelDifficultLoop.GetCurrentLevelDifficulty(levelNumber);

        switch (diff)
        {
            case LevelDifficulty.Easy:
                parameters = new EasyLevelParameters();
                break;
            case LevelDifficulty.Medium:
                parameters = new MediumLevelParameters();
                break;
            case LevelDifficulty.Hard:
                parameters = new HardLevelParameters();
                break;
            default:
                parameters = new EasyLevelParameters();
                break;

        }

        roomGenerator = GameObject.FindObjectOfType<RoomGenerator>();

        //TODO: make this random
        Room room = new Room(parameters.roomWidth, parameters.roomLenth, parameters.roomHeight, RoomType.Kitchen);
        roomGenerator.CreateRoom(room);
        roomGenerator.CreateDust(room, parameters.dustXDistance, parameters.dustYDistance);
    }
}




