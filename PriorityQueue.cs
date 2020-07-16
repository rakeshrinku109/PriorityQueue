using System;
using System.Collections.Generic;
using System.Text;

namespace Algotest
{
    public class PriorityQueue<T>
    {
        List<T> nodes = new List<T>();

        private readonly IComparer<T> comparer;

        public PriorityQueue(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        public int Count => nodes.Count;

        public void Add(T number)
        {
            nodes.Add(number);
            HeapifyUp(Count - 1);
        }

        public void HeapifyUp(int index)
        {
            int parent = (index - 1) / 2;

            if (parent >= 0 && this.comparer.Compare(nodes[parent],nodes[index]) > 0)
            {
                swap(parent, index);
                HeapifyUp(parent);
            }
        }

        public void Heapify(int index)
        {
            int left = 2 * index + 1;
            int right = 2 * index + 2;
            int thresHold = index;

            if (left < Count && this.comparer.Compare(nodes[thresHold],nodes[left]) > 0)
            {
                thresHold = left;
            }

            if (right < Count && this.comparer.Compare(nodes[thresHold], nodes[right]) > 0)
            {
                thresHold = right;
            }

            if (thresHold != index)
            {
                swap(thresHold, index);
                Heapify(thresHold);
            }
        }

        public void swap(int index1, int index2)
        {
            T temp = nodes[index1];
            nodes[index1] = nodes[index2];
            nodes[index2] = temp;
        }

        public T FindMin()
        {
            if (Count > 0)
                return nodes[0];
            else
                return default(T);
        }

        public T DeleteMin()
        {
            T MinimumValue = default(T);
            if (Count != 0)
            {
                swap(0, Count - 1);
                MinimumValue = nodes[Count - 1];
                nodes.RemoveAt(Count - 1);
            }
            Heapify(0);
            return MinimumValue;
        }
    }
}
