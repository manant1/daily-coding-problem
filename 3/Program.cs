using System;
using System.Collections.Generic;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Solution for problem #3");
            Program program = new Program();
            program.Start();
        }

        private void Start()
        {
            BinaryTree<string> binaryTree = new BinaryTree<string>("root");
            binaryTree.AddNode("left");
            binaryTree.AddNode("right");
            binaryTree.AddNode("left.left");
            Console.WriteLine(binaryTree.Deserialize(binaryTree.Serialize(binaryTree.GetHead())).GetLeft().GetLeft());
        }
    }

    class BinaryTree<T>
    {
        BinaryTreeNode<T> head;

        public BinaryTree(T value)
        {
            this.head = new BinaryTreeNode<T>(value);
        }

        public BinaryTree(BinaryTreeNode<T> node)
        {
            this.head = node;
        }

        public BinaryTreeNode<T> GetHead()
        {
            return this.head;
        }

        public void AddNode(T value)
        {
            Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(this.head);

            while (queue.Count != 0)
            {
                BinaryTreeNode<T> node = queue.Dequeue();

                if (node.GetLeft() == null)
                {
                    node.SetLeft(new BinaryTreeNode<T>(value));
                    break;
                }
                else
                {
                    queue.Enqueue(node.GetLeft());
                }

                if (node.GetRight() == null)
                {
                    node.SetRight(new BinaryTreeNode<T>(value));
                    break;
                }
                else
                {
                    queue.Enqueue(node.GetRight());
                }
            }
        }

        public string Serialize(BinaryTreeNode<T> node, string serializedString = "")
        {
            if (node == null)
            {
                serializedString += "# ";
                return serializedString;
            }

            serializedString += node.ToString() + " ";
            serializedString = Serialize(node.GetLeft(), serializedString);
            serializedString = Serialize(node.GetRight(), serializedString);

            return serializedString;
        }

        int index = 0;

        public BinaryTreeNode<T> Deserialize(string serializedBinaryTree)
        {
            if (serializedBinaryTree[this.index] == '#')
            {
                if (this.index < serializedBinaryTree.Length - 2)
                {
                    this.index += 2;
                }
                return null;
            }
            else
            {
                int length = serializedBinaryTree.IndexOf(" ", this.index) - this.index;
                string value = serializedBinaryTree.Substring(this.index, length);
                this.index += value.Length + 1;
                BinaryTreeNode<T> node = new BinaryTreeNode<T>((T)Convert.ChangeType(value, typeof (T)));
                node.SetLeft(Deserialize(serializedBinaryTree));
                node.SetRight(Deserialize(serializedBinaryTree));
                return node;
            }
        }

        //Inorder traversal (left, root, right)
        public void PrintBinaryTree(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            PrintBinaryTree(node.GetLeft());

            Console.Write(node.ToString() + " ");

            PrintBinaryTree(node.GetRight());
        }
    }

    class BinaryTreeNode<T>
    {
        private T value;
        private BinaryTreeNode<T> left = null;
        private BinaryTreeNode<T> right = null;

        public BinaryTreeNode(T value)
        {
            this.value = value;
        }

        public void SetValue(T value)
        {
            this.value = value;
        }

        public T GetValue(T value)
        {
            return this.value;
        }

        public void SetLeft(BinaryTreeNode<T> left)
        {
            this.left = left;
        }

        public BinaryTreeNode<T> GetLeft()
        {
            return this.left;
        }

        public void SetRight(BinaryTreeNode<T> right)
        {
            this.right = right;
        }

        public BinaryTreeNode<T> GetRight()
        {
            return this.right;
        }

        public override string ToString()
        {
            return this.value.ToString();
        }
    }
}
