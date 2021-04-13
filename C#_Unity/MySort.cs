using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MySort : MonoBehaviour
{
    List<int> dummylist;

    void Start()
    {
        dummylist = new List<int>();
        dummylist = getRandomInt(50,10,200);

        dummylist = QuickSort(dummylist);

        string a = "";
        for(int i=0;i<dummylist.Count; ++i)
        {
            a += dummylist[i] + " ";
        }

        UnityEngine.Debug.Log(a);
    }




    List<int> QuickSort(List<int> data)
    {
        if (data.Count <= 1)
            return data;

        int pivot = data[0];
        List<int> left = new List<int>();
        List<int> right = new List<int>();

        UnityEngine.Debug.Log("pivot is  == " + pivot);

        for(int i = 1; i<data.Count; ++i)
        {
            if (data[i] > pivot)
                right.Add(data[i]);
            else
                left.Add(data[i]);
        }

        left = QuickSort(left);
        right = QuickSort(right);

        left.Add(pivot);
        left.AddRange(right);
        return left;
    }


    public List<int> getRandomInt(int length, int min, int max)
    {
        List<int> randArray = new List<int>();

        while(true)
        {
            if (randArray.Count == length)
                break;

            randArray.Add(Random.Range(min, max));
            randArray = randArray.Distinct().ToList();
        }

        return randArray;
    }

}
