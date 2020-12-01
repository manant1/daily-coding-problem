using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Solution for problem #6");
            Program program = new Program();
            int[] array = { 1, 2, 3 };
            program.Start(array);
        }

        private unsafe void Start(int[] array)
        {
            XorLinkedList xorLinkedList = new XorLinkedList(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                xorLinkedList.Add(array[i]);
            }

            Console.WriteLine("XorList values:");
            foreach (int value in xorLinkedList)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine("Value at index 2 is: {0}", xorLinkedList.Get(2));
        }

        unsafe class XorLinkedList : IEnumerable<int>
        {
            XorLinkedListNode* head;
            XorLinkedListNode* prev;
            XorLinkedListNode* curr;
            XorLinkedListNode* next;
            XorLinkedListNode* tail;
            int index = 0;

            public XorLinkedList(int value)
            {
                curr = (XorLinkedListNode*)Marshal.AllocHGlobal(sizeof(XorLinkedListNode));
                this.head = curr;
                curr->SetValue(value);
            }

            public void Add(int value)
            {
                next = (XorLinkedListNode*)Marshal.AllocHGlobal(sizeof(XorLinkedListNode));
                next->SetValue(value);
                if (prev == null)
                {
                    curr->SetBoth((XorLinkedListNode*)(0 ^ (ulong)next));
                }
                else
                {
                    curr->SetBoth((XorLinkedListNode*)((ulong)prev ^ (ulong)next));
                }
                prev = curr;
                curr = next;
                tail = curr;
            }

            public int Get(int index)
            {
                int i = 0;
                foreach (int value in this)
                {
                    if (i == index)
                    {
                        return value;
                    }
                    i++;
                }
                return -1;
            }

            public XorLinkedListNode* GetFirst()
            {
                return head;
            }

            public XorLinkedListNode* GetLast()
            {
                return tail;
            }

            public static XorLinkedListNode* Xor(XorLinkedListNode* previous,
                                    XorLinkedListNode* prevXORnext)
            {
                return (XorLinkedListNode*)((ulong)previous ^ (ulong)prevXORnext);
            }

            public IEnumerator<int> GetEnumerator()
            {
                return new XorListEnumerator(head, tail);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }

            internal class XorListEnumerator : IEnumerator<int>, IEnumerable<int>
            {
                private XorLinkedListNode* head;
                private XorLinkedListNode* tail;
                private XorLinkedListNode* curr;
                private XorLinkedListNode* prev;

                public XorListEnumerator(XorLinkedListNode* head, XorLinkedListNode* tail)
                {
                    this.head = head;
                    this.curr = null;
                    this.tail = tail;
                }

                public int Current
                {
                    get { return curr->GetValue(); }
                }

                object IEnumerator.Current => Current;

                public void Dispose()
                {
                }

                public IEnumerator<int> GetEnumerator()
                {
                    return new XorListEnumerator(head, tail);
                }

                public bool MoveNext()
                {
                    if (curr == null)
                    {
                        curr = head;
                        return true;
                    }
                    if (curr == tail)
                    {
                        return false;
                    }
                    XorLinkedListNode* old = curr;
                    curr = XorLinkedList.Xor(prev, old->GetBoth());
                    prev = old;
                    return true;
                }

                public void Reset()
                {
                    curr = head;
                }

                IEnumerator IEnumerable.GetEnumerator()
                {
                    return GetEnumerator();
                }
            }
        }

        private unsafe struct XorLinkedListNode
        {
            private int value;
            private XorLinkedListNode* both;

            public XorLinkedListNode(int value)
            {
                this.value = value;
                both = null;
            }

            public XorLinkedListNode* GetBoth()
            {
                return both;
            }

            public void SetBoth(XorLinkedListNode* xor)
            {
                both = xor;
            }

            public void SetValue(int value)
            {
                this.value = value;
            }

            public int GetValue()
            {
                return this.value;
            }

            public override bool Equals(object obj)
            {
                return this.GetHashCode() == ((XorLinkedListNode)obj).GetHashCode();
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public override string ToString()
            {
                return value.ToString();
            }
        }
    }
}