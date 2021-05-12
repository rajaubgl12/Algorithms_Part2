using System.Collections.Generic;

namespace GeeksForGeeksRevision.DesignAlgos
{
    public class LRUCache
    {
        public int Capacity;
        DoublyNode head;
        DoublyNode tail;
        Dictionary<int, DoublyNode> map = new Dictionary<int, DoublyNode>();
        public LRUCache(int capacity)
        {
            Capacity = capacity;
            head = new DoublyNode(-1, 0);
            tail = new DoublyNode(-1, 0);
            head.next = tail;
            tail.prev = head;
        }

        public int Get(int key)
        {
            if (!map.ContainsKey(key))
                return -1;

            DoublyNode foundNode =  map[key];

            RemoveNode(foundNode);
            AddNodeFront(foundNode);

            return foundNode.Data;
        }

        public void Put(int key, int value)
        {
            if(!map.ContainsKey(key))
            {
                DoublyNode node = new DoublyNode(key, value);
                map.Add(key, node);
                //Addnode in front
                AddNodeFront(node);
            }
            else
            {
                DoublyNode foundNode = map[key];
                foundNode.Data = value;
                //remove node
                RemoveNode(foundNode);
                //add front
                AddNodeFront(foundNode);
            }

            if (map.Count <= Capacity)
                return;

            map.Remove(tail.prev.Key);
            RemoveNode(tail.prev);
        }
        private void AddNodeFront(DoublyNode node)
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
        private void RemoveNode(DoublyNode center)
        {
            // store temp prev and next
            var prev = center.prev;
            var next = center.next;

            // connect prev and next, so it will remove current.
            prev.next = next;
            next.prev = prev;
        }
    }

    public class DoublyNode
    {
        public DoublyNode prev = null;
        public  DoublyNode next = null;
        public int Data;
        public int Key;
        public DoublyNode(int key, int value)
        {
            Data = value;
            Key = key;
        }
    }

    /**
     * Your LRUCache object will be instantiated and called as such:
     * LRUCache obj = new LRUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */
}
