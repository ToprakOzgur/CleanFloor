using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelParameters
{
    public abstract float roomWidth { get; }
    public abstract float roomLenth { get; }
    public float roomHeight => 4.0f;

    public int dustXDistance => 1;
    public int dustYDistance => 1;
}
