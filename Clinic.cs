using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicHolding
{
    public class Clinic : IEnumerable<Room>
    {
        public string Name { get; set; }
        public List<Room> Rooms { get; set; }

        public Clinic(string name, int roomsCount)
        {
            if (roomsCount % 2 == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Name = name;
            Rooms = new List<Room>();
            for (int i = 1; i <= roomsCount; i++)
            {
                Rooms.Add(new Room(i));
            }
        }

        public bool AddPet(Pet pet)
        {
            List<int> roomOrder = ComputeAddRoomOrder();
            foreach (int index in roomOrder)
            {
                if (Rooms[index].AddPet(pet))
                {
                    return true;
                }
            }
            return false;
        }

        public bool ReleasePet()
        {
            List<int> roomOrder = ComputeReleaseRoomOrder();
            foreach (int index in roomOrder)
            {
                if (Rooms[index].ReleasePet())
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasEmptyRooms()
        {
            foreach (Room room in Rooms)
            {
                if (room.IsEmpty())
                {
                    return true;
                }
            }
            return false;
        }

        public void PrintClinic()
        {
            foreach (Room room in Rooms)
            {
                Console.WriteLine(room);
            }
        }

        public void PrintRoom(int roomNumber)
        {
            if (roomNumber >= 1 && roomNumber <= Rooms.Count)
            {
                Console.WriteLine(Rooms[roomNumber - 1]);
            }
        }

        // Implementing IEnumerable<Room> and GetEnumerator()
        public IEnumerator<Room> GetEnumerator()
        {
            return new RoomEnumerator(Rooms);
        }

        // Explicit interface implementation for non-generic IEnumerator
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // Custom Enumerator for Room
        private class RoomEnumerator : IEnumerator<Room>
        {
            private List<Room> _rooms;
            private int _currentIndex;

            public RoomEnumerator(List<Room> rooms)
            {
                _rooms = rooms;
                _currentIndex = -1;
            }

            public Room Current => _rooms[_currentIndex];

            object System.Collections.IEnumerator.Current => Current;

            public bool MoveNext()
            {
                _currentIndex++;
                return _currentIndex < _rooms.Count;
            }

            public void Reset()
            {
                _currentIndex = -1;
            }

            public void Dispose() { }
        }

        // Method to calculate the dynamic order for adding pets
        private List<int> ComputeAddRoomOrder()
        {
            List<int> order = new List<int>();
            int centerIndex = Rooms.Count / 2;

            // Start with the center room
            order.Add(centerIndex);

            // Alternately add left and right rooms
            int left = centerIndex - 1;
            int right = centerIndex + 1;

            while (order.Count < Rooms.Count)
            {
                if (left >= 0)
                {
                    order.Add(left);
                    left--;
                }
                if (right < Rooms.Count)
                {
                    order.Add(right);
                    right++;
                }
            }

            return order;
        }

        // Method to calculate the dynamic order for releasing pets
        private List<int> ComputeReleaseRoomOrder()
        {
            List<int> order = new List<int>();
            int centerIndex = Rooms.Count / 2;

            // Start with the center room
            order.Add(centerIndex);

            // First go to the right (wrapping around if necessary)
            int right = centerIndex + 1;

            while (right < Rooms.Count)
            {
                order.Add(right);
                right++;
            }

            // Now go leftward (wrapping around if necessary)
            int left = centerIndex - 1;

            while (left >= 0)
            {
                order.Add(left);
                left--;
            }

            return order;
        }
    }

}
