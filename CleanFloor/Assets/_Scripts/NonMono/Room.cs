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
    public float width;
    public float length;
    public float height;

    public RoomType roomtype;


    public Room(float width, float length, float height, RoomType roomtype)
    {
        this.width = width;
        this.length = length;
        this.height = height;
        this.roomtype = roomtype;

    }


    #region updown walls
    public Vector3 upWallPosition()
    {
        return new Vector3(0, height * 5, 5 * length);
    }
    public Quaternion upWallRotation()
    {
        return Quaternion.Euler(270, 0, 0);
    }
    public Vector3 downWallPosition()
    {
        return new Vector3(0, height * 5, -5 * length);
    }
    public Quaternion downWallRotation()
    {
        return Quaternion.Euler(90, 0, 0);
    }

    public Vector3 upDownWallScale()
    {
        return new Vector3(width, 1, height);
    }

    #endregion

    #region  left/right walls

    public Vector3 leftWallPosition()
    {
        return new Vector3(-5 * width, height * 5, 0);
    }
    public Quaternion leftWallRotation()
    {
        return Quaternion.Euler(90, 0, 270);
    }
    public Vector3 rightWallPosition()
    {
        return new Vector3(5 * width, height * 5, 0);
    }
    public Quaternion rightWallRotation()
    {
        return Quaternion.Euler(90, 0, 90);
    }

    public Vector3 righLeftWallScale()
    {
        return new Vector3(length, 1, height);
    }
    #endregion

}
