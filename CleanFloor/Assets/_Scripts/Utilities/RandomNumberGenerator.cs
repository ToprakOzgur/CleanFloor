using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomNumberGenerator
{
    public static int seed = 1;

    public static int NextRandomInt(int min, int max)
    {
        System.Random prng = new System.Random(seed);
        var r = prng.Next(min, max);
        Debug.Log("Donen Random =" + r);
        return r;
    }
    public static int NextRandomInt(int min, int max, int reversedSeed)
    {
        System.Random prng = new System.Random(reversedSeed - seed);
        var r = prng.Next(min, max);
        Debug.Log("Donen Random =" + r);
        return r;
    }
}
