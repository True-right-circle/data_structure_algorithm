using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomInt 
{
    public static List<int> getRandomInt(int length, int min, int max)
    {
        List<int> randArray = new List<int>();

        while (true)
        {
            if (randArray.Count == length)
                break;

            randArray.Add(Random.Range(min, max));
            randArray = randArray.Distinct().ToList();
        }

        return randArray;
    }
}
