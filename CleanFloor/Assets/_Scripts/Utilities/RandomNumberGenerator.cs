using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomNumberGenerator
{
    public static int seed = 1;

    public static int NextRandomInt(int min, int max, bool reverseSeed = false)
    {
        if (reverseSeed)
            seed = 9999 - seed;
        System.Random prng = new System.Random(seed);
        var r = prng.Next(min, max);
        Debug.Log("Donen Random =" + r);
        return r;
    }

}
