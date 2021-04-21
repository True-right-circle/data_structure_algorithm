using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyHash : MonoBehaviour
{
    List<string> hash_table = null;
    List<List<string>> chaining_table = null;
    public int getKey(string k)
    {
        return k[0];
    }

    public int hashfunc(int key)
    {
        return key % 8;
    }

    //linear probing
    void linearsetHash(int hashadrress, string data)
    {
        int key = getKey(data);
        if (hash_table[hashadrress].Equals("0"))
            hash_table[hashadrress] = "[" + data + "," +"key:" + key+"]";
        else
        {
            for(int i= hashadrress; i<hash_table.Count; ++i)
            {
                if (hash_table[i].Equals("0"))
                {
                    hash_table[i] = "[" + data + "," + "key : " + key + "]";
                    return;
                }
            }

            UnityEngine.Debug.Log("No more space");
        }
    }

    void chainningHash(int hashadrress, string data)
    {
        int key = getKey(data);

    }

    void Start()
    {
        string data = "jin";
        hash_table = new List<string> ();
        string phone = "0109374801";
        int key = getKey(data);
        int hashaddress = hashfunc(key);
       
        for(int i = 0; i< 8; ++i)
        {
            hash_table.Add("0");
        }

        linearsetHash(hashaddress, phone);
        linearsetHash(hashaddress, "24892734987290834");

        string h = "";
        foreach (var lst in hash_table)
        {
            h += lst + " ";
        }

       //UnityEngine.Debug.Log("\n"+h);

        chaining_table = new List<List<string>>();



        string k = "";
        foreach (var lst in chaining_table)
        {
            k += lst + " \n";
        }

        //UnityEngine.Debug.Log("\n" + k);
    }

}
