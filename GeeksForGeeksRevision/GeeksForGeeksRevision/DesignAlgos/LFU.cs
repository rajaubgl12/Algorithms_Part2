using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.DesignAlgos
{
    class LFUCache
    {
        int capacity;
        DoublyNode1 head;
        DoublyNode1 tail;
        //freq map which will have key as node key and value as count
        Dictionary<int, int> freqKeyMap = new Dictionary<int, int>();
        Dictionary<int, DoublyNode1> keyNodeMap = new Dictionary<int, DoublyNode1>();
        public LFUCache(int _capacity)
        {
            this.capacity = _capacity;
            head = new DoublyNode1(-1, -1);
            tail = new DoublyNode1(-1, -1);
            head.next = tail;
            tail.prev = head;
        }

        public int Get(int key)
        {
            return 0;
        }

        public void Put(int key, int value)
        {
            if (keyNodeMap.ContainsKey(key))
            {
                //if already exists then update the frequency
                freqKeyMap[key]++;
                //bring the node front
                DoublyNode1 foundNode = keyNodeMap[key];
                //remove the node
                RemoveNode(foundNode);
                //bring it front
                AddNodeFront(foundNode);
            }
            if (!keyNodeMap.ContainsKey(key))
            {
                //check the capacity.

                //Add node
                DoublyNode1 node = new DoublyNode1(key, value);
                DoublyNode1 temp = head;
                temp.prev = node;
                node.next = temp;
                node.prev = null;
                keyNodeMap.Add(key, node);
                freqKeyMap.Add(key, 1);
            }
        }

        private void AddNodeFront(DoublyNode1 node)
        {
            // store temp
            var temp = head.next;

            // connect head and new node
            head.next = node;
            node.prev = head;

            // connect new node and store temp node.
            node.next = temp;
            temp.prev = node;
        }
        private void RemoveNode(DoublyNode1 center)
        {
            // store temp prev and next
            var prev = center.prev;
            var next = center.next;

            // connect prev and next, so it will remove current.
            prev.next = next;
            next.prev = prev;
        }
    }
    internal class DoublyNode1
    {
        public int key;
        public int data;
       public DoublyNode1 prev;
       public DoublyNode1 next;
        public DoublyNode1(int key, int value)
        {
            this.key = key;
            this.data = value;
        }
    }
}
