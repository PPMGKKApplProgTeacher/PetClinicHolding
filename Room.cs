using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicHolding
{
    public class Room
    {
        public int Number { get; set; }
        public Pet PetInRoom { get; set; }

        public Room(int number)
        {
            Number = number;
            PetInRoom = null;
        }

        public bool IsEmpty()
        {
            return PetInRoom == null;
        }

        public bool AddPet(Pet pet)
        {
            if (IsEmpty())
            {
                PetInRoom = pet;
                return true;
            }
            return false;
        }

        public bool ReleasePet()
        {
            if (!IsEmpty())
            {
                PetInRoom = null;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            if (IsEmpty())
            {
                return "Room empty";
            }
            return $"{PetInRoom.Name} {PetInRoom.Age} {PetInRoom.Species}";
        }
    }
}
