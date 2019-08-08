using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public Room(RoomType roomtype)
    {
        this.roomtype = roomtype;
    }

}
