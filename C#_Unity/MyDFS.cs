using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDFS : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Dictionary<string,string> graph = new Dictionary<string, string>();
        //A
        graph.Add("A","BC");
        
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
        result = DFS(graph, "A");

        for (int i = 0; i < result.Count; ++i)
            r += result[i] + " ";

        UnityEngine.Debug.Log(r);
    }
    //visited => Queue
    //need_visited = stack
    List<string> DFS(Dictionary<string, string> graph, string start)
    {
        List<string> visited = new List<string>();
        List<string> need_visited = new List<string>() { start };


        while (need_visited.Count != 0)
        {
            if (!visited.Contains(need_visited[need_visited.Count - 1]))
            {
                string temp = need_visited[need_visited.Count - 1];
                visited.Add(temp);
                for (int i = 0; i < graph[temp].Length; ++i)
                {
                    need_visited.Add(graph[temp][i].ToString());
                }
                need_visited.Remove(temp);
            }
            else
            {
                string temp = need_visited[need_visited.Count - 1];
                need_visited.Remove(temp);
            }
        }


        return visited;
    }

}
