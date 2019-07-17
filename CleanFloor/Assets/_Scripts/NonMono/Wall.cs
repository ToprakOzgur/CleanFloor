using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WallDirection
{
    Up,
    Down,
    Left,
    Right,
}
public class Wall
{
    private WallDirection wallDirection;
    private Color color;
    private int length;

    public Wall(WallDirection wallDirection, Color color, int length)
    {
        this.wallDirection = wallDirection;
        this.color = color;
        this.length = length;
    }
}

