using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicHolding
{
    public class PetClinicManager
        {
            public Dictionary<string, Clinic> Clinics { get; set; }
            public Dictionary<string, Pet> Pets { get; set; }

            public PetClinicManager()
            {
                Clinics = new Dictionary<string, Clinic>();
                Pets = new Dictionary<string, Pet>();
            }

            public bool CreatePet(string name, int age, string species)
            {
                var pet = new Pet(name, age, species);
                Pets[name] = pet;
                return true;
            }

            public bool CreateClinic(string name, int roomsCount)
            {
                try
                {
                    var clinic = new Clinic(name, roomsCount);
                    Clinics[name] = clinic;
                    return true;
                }
                catch (InvalidOperationException)
                {
                    return false;
                }
            }

            public bool AddPetToClinic(string petName, string clinicName)
            {
                if (!Pets.ContainsKey(petName) || !Clinics.ContainsKey(clinicName))
                {
                    return false;
                }

                var pet = Pets[petName];
                var clinic = Clinics[clinicName];
                return clinic.AddPet(pet);
            }

            public bool ReleasePetFromClinic(string clinicName)
            {
                if (!Clinics.ContainsKey(clinicName))
                {
                    return false;
                }

                var clinic = Clinics[clinicName];
                return clinic.ReleasePet();
            }

            public bool HasEmptyRoomsInClinic(string clinicName)
            {
                if (!Clinics.ContainsKey(clinicName))
                {
                    return false;
                }

                var clinic = Clinics[clinicName];
                return clinic.HasEmptyRooms();
            }

            public void PrintClinic(string clinicName)
            {
                if (Clinics.ContainsKey(clinicName))
                {
                    Clinics[clinicName].PrintClinic();
                }
            }

            public void PrintRoom(string clinicName, int roomNumber)
            {
                if (Clinics.ContainsKey(clinicName))
                {
                    Clinics[clinicName].PrintRoom(roomNumber);
                }
            }
        }
}
