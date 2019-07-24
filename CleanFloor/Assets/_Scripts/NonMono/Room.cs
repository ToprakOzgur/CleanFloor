using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum RoomType
{
    Kitchen,
    Office,
    Bathroom,
}
public class Room
{
    public int width;
    public int length;
    public float height;

    public RoomType roomtype;


    public Room(int width, int length, float height, RoomType roomtype)
    {
        this.width = width;
        this.length = length;
        this.height = height;
        this.roomtype = roomtype;
        Debug.Log("width= " + width + "and length= " + length);
    }

}
