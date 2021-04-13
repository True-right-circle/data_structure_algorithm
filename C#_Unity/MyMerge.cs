using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MyMerge : MonoBehaviour
{
    List<int> dummylist;

    void Start()
    {
        dummylist = new List<int>();
        dummylist = getRandomInt(50, 10, 200);
        dummylist = Divid(dummylist);

        string result = "";
        for (int i = 0; i < dummylist.Count; ++i)
            result += dummylist[i] + " ";

        UnityEngine.Debug.Log(result);
    }

    public List<int> Merge(List<int> left, List<int> right)
    {
        List<int> total = new List<int>();
        int left_index = 0;
        int right_index = 0;

        //case 1 right, left both
        while(left.Count>left_index && right.Count>right_index)
        {
            if (left[left_index] > right[right_index])
            {
                total.Add(right[right_index]);
                right_index++;
            }
            else
            {
                total.Add(left[left_index]);
                left_index++;
            }
        }

        //case 2 left only
        while(left.Count > left_index)
        {
            total.Add(left[left_index]);
            left_index++;
        }

        //case 3 right only
        while(right.Count > right_index)
        {
            total.Add(right[right_index]);
            right_index++;
        }

        return total;
    }

    public List<int> Divid(List<int> data)
    {
        if (data.Count <= 1)
            return data;

        int div = data.Count / 2;
        List<int> left = new List<int>();
        List<int> right = new List<int>();

        for (int i = 0; i < div; ++i)
            left.Add(data[i]);

        for (int i = div; i < data.Count; ++i)
            right.Add(data[i]);

        left = Divid(left);
        right = Divid(right);

        return Merge(left, right);
    }

    public List<int> getRandomInt(int length, int min, int max)
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
