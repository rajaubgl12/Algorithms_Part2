using System;
using System.Collections.Generic;
using System.Text;

namespace IK_Algorithms.Graphs
{
    public class KeysAndRooms
    {
        public bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            HashSet<int> visited = new HashSet<int>();

            DFSRooms(0,rooms, visited);

            return visited.Count == rooms.Count;
        }

        private void DFSRooms(int room, IList<IList<int>> rooms, HashSet<int> visited)
        {
            visited.Add(room);
           foreach(int key in rooms[room])
            {
                if (visited.Contains(key))
                    continue;
                DFSRooms(key, rooms, visited);
            }
        }
    }
}
