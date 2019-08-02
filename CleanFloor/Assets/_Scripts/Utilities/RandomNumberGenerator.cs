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
        //  Debug.Log("Donen Random =" + r);
        return r;
    }
    public static int NextRandomInt(int min, int max, int reversedSeed)
    {
        System.Random prng = new System.Random(reversedSeed - seed);
        var r = prng.Next(min, max);
        // Debug.Log("Donen Random =" + r);
        return r;
    }

    public static T[] ShuffleArray<T>(T[] array)
    {
        System.Random prng = new System.Random(seed);

        for (int i = 0; i < array.Length - 1; i++)
        {
            int randomIndex = prng.Next(i, array.Length);
            T tempItem = array[randomIndex];
            array[randomIndex] = array[i];
            array[i] = tempItem;
        }
        return array;
    }
}
