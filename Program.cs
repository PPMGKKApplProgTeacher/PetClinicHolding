using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicHolding
{
    class Program
    {
        static void Main()
        {
            var manager = new PetClinicManager();
            int n = int.Parse(Console.ReadLine()); // броя на командите

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split();

                try
                {
                    if (command[0] == "Create" && command[1] == "Pet")
                    {
                        bool result = manager.CreatePet(command[2], int.Parse(command[3]), command[4]);
                        Console.WriteLine(result ? "True" : "False");
                    }
                    else if (command[0] == "Create" && command[1] == "Clinic")
                    {
                        bool result = manager.CreateClinic(command[2], int.Parse(command[3]));
                        Console.WriteLine(result ? "True" : "Invalid Operation!");
                    }
                    else if (command[0] == "Add")
                    {
                        bool result = manager.AddPetToClinic(command[1], command[2]);
                        Console.WriteLine(result ? "True" : "False");
                    }
                    else if (command[0] == "Release")
                    {
                        bool result = manager.ReleasePetFromClinic(command[1]);
                        Console.WriteLine(result ? "True" : "False");
                    }
                    else if (command[0] == "HasEmptyRooms")
                    {
                        bool result = manager.HasEmptyRoomsInClinic(command[1]);
                        Console.WriteLine(result ? "True" : "False");
                    }
                    else if (command[0] == "Print")
                    {
                        if (command.Length == 2)
                        {
                            manager.PrintClinic(command[1]);
                        }
                        else
                        {
                            manager.PrintRoom(command[1], int.Parse(command[2]));
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Operation!");
                }
            }
        }
    }
}