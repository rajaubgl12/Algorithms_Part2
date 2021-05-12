using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.DesignAlgos
{
    public class LFUCache2
    {

        private Dictionary<int, DLL> _freqListMap;
        private Dictionary<int, Node> _keyNodeMap;
        private int _minFreq;
        private int _capacity;
        private int _currSize;
        public LFUCache2(int capacity)
        {
            _freqListMap = new Dictionary<int, DLL>();
            _keyNodeMap = new Dictionary<int, Node>();
            _minFreq = 0;
            _capacity = capacity;
            _currSize = 0;
        }

        public int Get(int key)
        {
            if (false == _keyNodeMap.ContainsKey(key))
            {
                return -1;
            }
            var node = _keyNodeMap[key];
            UpdateFreq(node);
            return node.Value;
        }

        public void Put(int key, int value)
        {
            if (_capacity == 0)
            {
                return;
            }
            if (_keyNodeMap.ContainsKey(key))
            {
                //if already contains the key, just update the value and set the frequency
                Node node = _keyNodeMap[key];
                node.Value = value;
                UpdateFreq(node);
            }
            else
            {
                _currSize++;
                if (_currSize > _capacity)
                {
                    //need to evict LFU node
                    var ll = _freqListMap[_minFreq];
                    var nodeToDel = ll.RemoveFromLast();
                    _keyNodeMap.Remove(nodeToDel.Key);
                    _currSize--;
                }
                var n = new Node(key, value);
                _minFreq = 1;
                if (_freqListMap.ContainsKey(_minFreq))
                {
                    _freqListMap[_minFreq].Add(n);
                }
                else
                {
                    var newLst = new DLL();
                    newLst.Add(n);
                    _freqListMap[_minFreq] = newLst;
                }
                _keyNodeMap[key] = n;
            }

        }

        private void UpdateFreq(Node node)
        {
            //get the node from the list
            var oldLst = _freqListMap[node.Count];
            //remove from the old frequency list
            oldLst.Remove(node);
            //if current list the the last list which has lowest frequency and current node is the only node in that list
            // we need to remove the entire list and then increase min frequency value by 1
            //this is because the minfrequency is no longer what it was since there are no more elements in this list
            //so make the next higest frequency as the minFrequency
            if (node.Count == _minFreq && oldLst.Size == 0)
            {
                _minFreq++;
            }
            //update the node count
            node.Count++;
            //add to new freq map after updating the frequency
            if (false == _freqListMap.ContainsKey(node.Count))
            {
                _freqListMap[node.Count] = new DLL();
            }
            _freqListMap[node.Count].Add(node);

        }

        private class Node
        {
            public int Key;
            public int Value;
            public int Count;
            public Node Next;
            public Node Prev;

            public Node(int key, int value)
            {
                Key = key;
                Value = value;
                Count = 1;
            }
        }

        private class DLL
        {
            public Node Head;
            public Node Tail;
            public int Size;

            public DLL()
            {
                Head = new Node(0, 0);
                Tail = new Node(0, 0);
                Head.Next = Tail;
                Head.Prev = Tail;
                Tail.Next = Head;
                Tail.Prev = Head;
            }

            public void Add(Node n)
            {
                var nxtNode = Head.Next;
                n.Next = nxtNode;
                n.Prev = Head;
                nxtNode.Prev = n;
                Head.Next = n;
                this.Size++;
            }

            public void Remove(Node n)
            {
                var prevNode = n.Prev;
                var nxtNode = n.Next;
                prevNode.Next = n.Next;
                nxtNode.Prev = prevNode;
                this.Size--;
            }

            public Node RemoveFromLast()
            {
                if (Size > 0)
                {
                    Node toRemove = Tail.Prev;
                    Remove(toRemove);
                    return toRemove;
                }
                return null;
            }
        }
    }

    /**
     * Your LFUCache object will be instantiated and called as such:
     * LFUCache obj = new LFUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */
    
}
