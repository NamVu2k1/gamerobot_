using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class binarytree : MonoBehaviour
{
    // Start is called before the first frame update
    public class Node
    {
        public int key;
        public Node left, right;
        public Node(int item)
        {
            key = item;
            left = right = null;
        }

    }

    public class BinaryTree
    {
        public Node root;
        public BinaryTree()
        {
            root = null;
        }
        public Node search(int value)
        {
            Node current = root;

            while (current.key != value)
            {
                if (value > current.key)
                {
                    current = current.right;
                }
                else
                {
                    current = current.left;
                }
                if (current == null)
                {
                    return null;
                }
            }
            return current;
        }
        public void insert(int value)
        {
            Node newNode = new Node(value);
            if (root == null)
            {
                root = newNode;
            }
            else
            {
                Node current = root;
                Node parent;
                while (true)
                {
                    parent = current;
                    if (value < current.key)
                    {
                        current = current.left;
                        if (current == null)
                        {
                            parent.left = newNode;
                            return;
                        }

                    }
                    else
                    {
                        current = current.right;
                        if (current == null)
                        {
                            parent.right = newNode;
                            return;
                        }
                    }
                }

            }
        }

    }
    private void Start()
    {
        BinaryTree tree = new BinaryTree();
        tree.insert(5);
        tree.insert(3);
        tree.insert(6);
        tree.insert(2);
        tree.insert(4);
        Debug.Log(tree.search(1).key);

    }



}
