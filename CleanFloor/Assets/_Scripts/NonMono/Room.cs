using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum Roomdifficulty
{
    easy,
    medium,
    Hard
}

public enum RoomType
{
    Common,
    Kitchen,
    Toilet,
    Office,
    Living,
    BedMale,
    BedFemale
}
public class Room
{
    public RoomType roomtype;
    public Roomdifficulty roomdifficulty;
    public int obstacleCount;
    public int robotHealth;
    public int prefabNumber;


    readonly RoomsIdealParameters[] roomsIdealParameters = new RoomsIdealParameters[]{
    new RoomsIdealParameters{roomType=RoomType.Kitchen,prefabNumber=1,obsCount=7,demageTime=24},
    new RoomsIdealParameters{roomType=RoomType.Kitchen,prefabNumber=2,obsCount=7,demageTime=17},
    new RoomsIdealParameters{roomType=RoomType.Kitchen,prefabNumber=3,obsCount=7,demageTime=35},
    new RoomsIdealParameters{roomType=RoomType.Kitchen,prefabNumber=4,obsCount=7,demageTime=26},

    new RoomsIdealParameters{roomType=RoomType.Living,prefabNumber=1,obsCount=6,demageTime=16},
    new RoomsIdealParameters{roomType=RoomType.Living,prefabNumber=2,obsCount=5,demageTime=14},
    new RoomsIdealParameters{roomType=RoomType.Living,prefabNumber=3,obsCount=5,demageTime=29},
    new RoomsIdealParameters{roomType=RoomType.Living,prefabNumber=4,obsCount=6,demageTime=23},

    new RoomsIdealParameters{roomType=RoomType.Office,prefabNumber=1,obsCount=8,demageTime=24},
    new RoomsIdealParameters{roomType=RoomType.Office,prefabNumber=2,obsCount=6,demageTime=18},
    new RoomsIdealParameters{roomType=RoomType.Office,prefabNumber=3,obsCount=8,demageTime=25},
    new RoomsIdealParameters{roomType=RoomType.Office,prefabNumber=4,obsCount=8,demageTime=33},
    };

    public Room(RoomType _roomtype, Roomdifficulty _roomdifficulty, int _prefabNumber)
    {
        this.roomtype = _roomtype;
        this.roomdifficulty = _roomdifficulty;
        this.prefabNumber = _prefabNumber;

    }

    public void SetUpRoom()
    {
        obstacleCount = RandomNumberGenerator.NextRandomInt(GetMinRoomObstacleCount(), GetMaxRoomObstacleCount() + 1);
        robotHealth = RandomNumberGenerator.NextRandomInt(GetMinRobotHealth(), GetMaxRobotHealth() + 1);

    }
    private int GetMinRoomObstacleCount()
    {
        var idealMediumDiffObsCount = roomsIdealParameters.First(x => x.prefabNumber == prefabNumber && x.roomType == roomtype).obsCount;

        switch (roomdifficulty)
        {
            case Roomdifficulty.easy:
                idealMediumDiffObsCount -= 3;
                break;
            case Roomdifficulty.medium:
                idealMediumDiffObsCount -= 1;
                break;
            case Roomdifficulty.Hard:
                idealMediumDiffObsCount += 1;
                break;
        }

        return idealMediumDiffObsCount;
    }
    private int GetMaxRoomObstacleCount()
    {
        var idealMediumDiffObsCount = roomsIdealParameters.First(x => x.prefabNumber == prefabNumber && x.roomType == roomtype).obsCount;

        switch (roomdifficulty)
        {
            case Roomdifficulty.easy:
                idealMediumDiffObsCount -= 1;
                break;
            case Roomdifficulty.medium:
                idealMediumDiffObsCount += 1;
                break;
            case Roomdifficulty.Hard:
                idealMediumDiffObsCount += 3;
                break;
        }

        return idealMediumDiffObsCount;
    }
    private int GetMaxRobotHealth()
    {
        var idealMediumDemageTime = roomsIdealParameters.First(x => x.prefabNumber == prefabNumber && x.roomType == roomtype).demageTime;

        switch (roomdifficulty)
        {
            case Roomdifficulty.easy:
                idealMediumDemageTime += 16;
                break;
            case Roomdifficulty.medium:
                idealMediumDemageTime += 10;
                break;
            case Roomdifficulty.Hard:
                idealMediumDemageTime += 4;
                break;
        }

        return idealMediumDemageTime;
    }

    private int GetMinRobotHealth()
    {
        var idealMediumDemageTime = roomsIdealParameters.First(x => x.prefabNumber == prefabNumber && x.roomType == roomtype).demageTime;

        switch (roomdifficulty)
        {
            case Roomdifficulty.easy:
                idealMediumDemageTime += 12;
                break;
            case Roomdifficulty.medium:
                idealMediumDemageTime += 6;
                break;
            case Roomdifficulty.Hard:
                //idealMediumDemageTime -= 0;
                break;
        }

        return idealMediumDemageTime;
    }


}
public struct RoomsIdealParameters
{
    public RoomType roomType;
    public int prefabNumber;
    public int obsCount;
    public int demageTime;


}
