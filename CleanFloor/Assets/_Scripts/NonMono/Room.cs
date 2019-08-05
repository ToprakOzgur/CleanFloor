using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
    public Room(RoomType roomtype)
    {
        this.roomtype = roomtype;
    }

}
