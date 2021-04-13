using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBianryTree : MonoBehaviour
{
    public class Node
    {
        public int data;
        public Node left;
        public Node rigth;

        public Node(int value)
        {
            data = value;
            left = null;
            rigth = null;
        }
    }

    public class BSTMng
    {
        private Node root = null;

        public BSTMng()
        {
           // root = new Node(data);
        }

        // less than memory
        public void insert(int data)
        {
            if (root == null)
            {
                root = new Node(data);
                return;
            }

            Node CurrentNode = root;

            while (CurrentNode!=null)
            {
                if (data < CurrentNode.data)
                {
                    if(CurrentNode.left == null)
                    {
                        CurrentNode.left = new Node(data);
                        return;
                    }
                    CurrentNode = CurrentNode.left;
                }
                else
                {
                    if (CurrentNode.rigth == null)
                    {
                        CurrentNode.rigth = new Node(data);
                        return;
                    }
                    CurrentNode = CurrentNode.rigth;
                }
            }
           
        }

        public void Search(int data)
        {
            if (root == null)
            {
                UnityEngine.Debug.Log("No data");
                return;
            }

            if(root.data==data)
            {
                UnityEngine.Debug.Log("Find data R == " + root.data);
                return;
            }

            Node currentNode = root;
            while (currentNode != null)
            {
                if(data == currentNode.data)
                {
                    UnityEngine.Debug.Log("Find data L == " + currentNode.data);
                    return;
                }

                if(data<currentNode.data)
                {
                    currentNode = currentNode.left;
                    //UnityEngine.Debug.Log("Find data L == " + currentNode.data);
                }
                else
                {
                    currentNode = currentNode.rigth;
                }
            }

            UnityEngine.Debug.Log("Find No data == " + data);

        }


        //Del case 1: No_child
        //Del case 2: One_child
        //Del case 3: Two_child
        public void Delete(int data)
        {
            if (root == null)
            {
                UnityEngine.Debug.Log("No data");
                return;
            }

            Node currentNode = root;
            Node parentNode = root;
            
            while(currentNode != null)
            {
                if(data == currentNode.data)
                {
                    break;
                }
                if(data< currentNode.data)
                {
                    parentNode = currentNode;
                    currentNode = currentNode.left;
                }
                else
                {
                    parentNode = currentNode;
                    currentNode = currentNode.rigth;
                }
            }

            if (currentNode == null)
            {
                UnityEngine.Debug.Log("There in No  " + data);
                return;
            }

            UnityEngine.Debug.Log(currentNode.data);
            //case 1
            if (currentNode.rigth == null && currentNode.left == null)
            {
                UnityEngine.Debug.Log("here on this case 1");
                if (currentNode.data < parentNode.data)
                {
                    parentNode.left = null;
                    currentNode = null;
                }
                else
                {
                    parentNode.rigth = null;
                    currentNode = null;
                }
            }
            //case2 오른쪽 노드만 있는경우
            else if (currentNode.rigth != null && currentNode.left == null)
            {
                UnityEngine.Debug.Log("here on this case 2-1");
                if (currentNode.data < parentNode.data)
                {
                    parentNode.left = null;
                    parentNode.left = currentNode.rigth;

                    currentNode.rigth = null;
                    currentNode = null;
                }
                else
                {
                    parentNode.rigth = null;
                    parentNode.rigth = currentNode.rigth;

                    currentNode.rigth = null;
                    currentNode = null;
                }
            }
            //case2 왼쪽 노드만 있는 경우
            else if (currentNode.rigth == null && currentNode.left != null)
            {
                UnityEngine.Debug.Log("here on this case 2-2");
                if (currentNode.data < parentNode.data)
                {
                    parentNode.left = null;
                    parentNode.left = currentNode.rigth;

                    currentNode.left = null;
                    currentNode = null;
                }
                else
                {
                    parentNode.rigth = null;
                    parentNode.rigth = currentNode.rigth;

                    currentNode.left = null;
                    currentNode = null;
                }
            }
            //case3 Two child
            else if (currentNode.rigth != null && currentNode.left != null)
            {
                //parent좌우 체크
                //삭제하려는 노드의 오른쪽 영역에서 값이 작은 Node를(가장 왼쪽) 삭제할 노드 자리로 올린다.
                //올리려는 노드에 자식이 있을경우, 없을 경우 -> 해당 노드는 가장 왼쪽 노드이기 때문에 왼쪽 자식이 있을 경우는 없다
                UnityEngine.Debug.Log("here on this case 3");
                Node changed_node = currentNode.rigth;
                Node changed_node_parent = currentNode.rigth;
                while (changed_node.left != null)
                {
                    changed_node_parent = changed_node;
                    changed_node = changed_node.left;
                }
                //parent좌우 체크
                if (changed_node.rigth !=null)
                {
                    UnityEngine.Debug.Log("here on this case 3 - 2");
                    

                    changed_node_parent.left = changed_node.rigth;
                    changed_node.rigth = null;

                    changed_node.left = currentNode.left;
                    currentNode.left = null;
                    changed_node.rigth = currentNode.rigth;
                    currentNode.rigth = null;
                    currentNode = null;

                }
                else
                {
                    UnityEngine.Debug.Log("here on this case 3 - 1");
                    changed_node.left = currentNode.left;
                    changed_node.rigth = currentNode.rigth;
                    currentNode = null;
                    changed_node_parent.left = null;

                }

                if (parentNode.data < changed_node.data)
                {
                    parentNode.rigth = changed_node;
                }
                else
                {
                    parentNode.left = changed_node;
                }
            }
        }
    }


    private void Start()
    {
        List<int> Dummyarray = new List<int>() { 91, 32, 3, 104, 25, 66, 77, 98, 9, 100, 1, 22 };
        BSTMng MyTree = new BSTMng();

        for(int i =0; i< Dummyarray.Count; ++i)
        {
            MyTree.insert(Dummyarray[i]);
        }

        MyTree.Delete(3);
        MyTree.Search(3);
        MyTree.Search(9);
        MyTree.Delete(32);
    }
}
