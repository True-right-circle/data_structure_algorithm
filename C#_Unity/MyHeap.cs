using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyHeap : MonoBehaviour
{
    //index -> start 1 is easier than start 9
    //left = index *2
    //right = (index *2)+1
    //parent = index//2
    class Heap
    {
        public List<int> heapArray =  null;
        public Heap(int in_data)
        {
            heapArray = new List<int>() { 0 }; //index 0 dummy
            heapArray.Add(in_data); 
        }

        public bool MoveUP(int index)
        {
            int parent_index = index / 2;
            if (parent_index == 0)
                return false;
            if (heapArray[index] > heapArray[parent_index])
                return true;

            return false;

        }
        public void insert(int data)
        {
            if(heapArray.Count<=1)
            {
                heapArray.Add(data); //index 0 dummy
                return;
            }

            heapArray.Add(data);

            //Compare & swap
            int c_index = heapArray.Count-1;

            while(MoveUP(c_index))
            {
                int parent_index = (c_index) / 2;
                int temp = heapArray[c_index];
                heapArray[c_index] = heapArray[parent_index];
                heapArray[parent_index] = temp;
                c_index = parent_index;
            }
        }

        // 1. 맨끝 데이터를 맨 앞으로 가져옴
        // 2. 맨끝 데이터 삭제
        // 3. 2가지 case를 돌며 정렬
        // - 1. 아예 자식 노드가 없을 경우
        // - 2. 왼쪽 노드만 있는 경우
        // - 3. 두 자식 노드가 있는 경우
        // - 3 - 1) 자식 노드끼리 먼저 비교
        // - 3 - 2) 2-1 더 큰 값과 부모 노드간 비교 후 swap 

        // Heap 특성상 오른쪽만 노드가 있을 경우는 없다
        public bool MoveDown(int poped_index)
        {
            int left_popped_index = poped_index * 2;
            int right_ppoped_index = (poped_index * 2) + 1;

            //노드가 없을 때 
            if (left_popped_index > heapArray.Count - 1)
                return false;
            else if(right_ppoped_index > heapArray.Count - 1)//왼쪽 노드만 존재시
            {
                if (heapArray[left_popped_index] > heapArray[poped_index])
                    return true;
                else
                    return false;
            }
            else //노드가 두개일 경우
            {
                // 1.자식간 비교
                if(heapArray[right_ppoped_index]> heapArray[left_popped_index])
                {
                    if (heapArray[right_ppoped_index] > heapArray[poped_index])
                        return true;
                    else
                        return false;
                }
                else
                {
                    if (heapArray[left_popped_index] > heapArray[poped_index])
                        return true;
                    else
                        return false;
                }
            }

            return false;
        }
        public void pop()
        {
            if (heapArray.Count <= 1)
            {
                UnityEngine.Debug.Log("No data");
                return;
            }

            heapArray[0] = heapArray[heapArray.Count-1];
            heapArray.RemoveAt(heapArray.Count - 1);

            //가장 맨위의 index
            int popped_index = 0;

            while(MoveDown(popped_index))
            {
                int left_popped_index = popped_index * 2;
                int right_ppoped_index = left_popped_index + 1;

                //노드가 없을 때 
                if (left_popped_index > heapArray.Count - 1)
                    break;
                else if (right_ppoped_index > heapArray.Count - 1)//왼쪽 노드만 존재시
                {
                    if (heapArray[left_popped_index] > heapArray[popped_index])
                    {
                        int temp = heapArray[left_popped_index];
                        heapArray[left_popped_index] = heapArray[popped_index];
                        heapArray[popped_index] = temp;
                        popped_index = left_popped_index;
                    }

                }
                else //노드가 두개일 경우
                {
                    // 1.자식간 비교
                    if (heapArray[right_ppoped_index] > heapArray[left_popped_index])
                    {
                        if (heapArray[right_ppoped_index] > heapArray[popped_index])
                        {
                            int temp = heapArray[right_ppoped_index];
                            heapArray[right_ppoped_index] = heapArray[popped_index];
                            heapArray[popped_index] = temp;
                            popped_index = right_ppoped_index;
                        }
                    }
                    else
                    {
                        if (heapArray[left_popped_index] > heapArray[popped_index])
                        {
                            int temp = heapArray[left_popped_index];
                            heapArray[left_popped_index] = heapArray[popped_index];
                            heapArray[popped_index] = temp;                                                              
                            popped_index = left_popped_index;
                        }
                    }
                }
            }

        }

        public string ShowList()
        {
            string List_srt = "";
            for (int i =1; i<heapArray.Count; ++i)
                List_srt += heapArray[i] + "  ";

            return List_srt;
        }

    }
    Heap h;
    public void OnclickPop()
    {
        h.pop();
        UnityEngine.Debug.Log(h.ShowList());
    }
    void Start()
    {
        h = new Heap(15);
        h.insert(20);
        h.insert(10);
        h.insert(8);
        h.insert(5);
        h.insert(4);
        h.insert(74);
        UnityEngine.Debug.Log(h.ShowList());
    }


}
