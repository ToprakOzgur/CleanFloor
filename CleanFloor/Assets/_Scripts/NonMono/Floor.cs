using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor
{
    private int width;
    private int length;

    private Color color;

    public Floor(int width, int length, Color color)
    {
        this.width = width;
        this.length = length;
        this.color = color;
    }
}
