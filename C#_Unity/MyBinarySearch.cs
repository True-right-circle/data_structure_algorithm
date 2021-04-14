using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBinarySearch : MonoBehaviour
{
    public bool BinarySearch(List<int> data, int search)
    {
        if (data.Count == 1 && data[0] == search)
            return true;

        if (data.Count == 1 && data[0] != search)
            return false;

        if (data.Count == 0)
            return false;

        int middle = data.Count / 2;
        List<int> left = new List<int>();
        List<int> right = new List<int>();

        for (int i = 0; i < middle; ++i)
            left.Add(data[i]);

        for (int i = middle; i < data.Count; ++i)
            right.Add(data[i]);

        if (search == data[middle])
            return true;
        else
        {
            if (data[middle] > search)
                return BinarySearch(left, search);
            else
                return BinarySearch(right, search);
        }
    }
    void Start()
    {
        List<int> DummyList = new List<int>();
        DummyList = RandomInt.getRandomInt(20,10,500);
        DummyList.Sort();
        string s = "";
        for (int i = 0; i < DummyList.Count; ++i)
            s += DummyList[i] + " ";

        UnityEngine.Debug.Log(s);
        UnityEngine.Debug.Log(BinarySearch(DummyList, 20));
    }

}
