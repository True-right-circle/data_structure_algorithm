using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBFS : MonoBehaviour
{
    //visit -> Queue
    //need_visit -> Queue
    // Start is called before the first frame update
    void Start()
    {
        Dictionary<string, string> graph = new Dictionary<string, string>();
        //A
        graph.Add("A", "BC");

        //B
        graph.Add("B", "AD");

        //C
        graph.Add("C", "AGHI");

        //D
        graph.Add("D", "BEF");

        //E
        graph.Add("E", "D");

        //F
        graph.Add("F", "D");

        //G
        graph.Add("G", "C");

        //H
        graph.Add("H", "C");

        //I
        graph.Add("I", "CJ");

        //J
        graph.Add("J", "I");

        //foreach(var a in graph)
        //{
        //    UnityEngine.Debug.Log(a.Key + "   " + a.Value);
        //
        //}
        List<string> result = new List<string>();
        string r = "";
        result = BFS(graph, "A");

        for (int i = 0; i < result.Count; ++i)
            r += result[i] + " ";

        UnityEngine.Debug.Log(r);
    }

    List<string> BFS(Dictionary<string, string> graph, string start)
    {
       List<string> visited = new List<string>();
       List<string> need_visit = new List<string>() { start };

        while (need_visit.Count != 0)
        {
            if(!visited.Contains(need_visit[0]))
            {
                visited.Add(need_visit[0]);
                for(int i=0; i<graph[need_visit[0]].Length; ++i)
                {
                    need_visit.Add(graph[need_visit[0]][i].ToString());
                }
                need_visit.RemoveAt(0);
            }
            else
            {
                need_visit.RemoveAt(0);
            }
        }
        return visited;

    }

}
