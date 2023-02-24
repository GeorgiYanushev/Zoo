using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooDB.Models;

namespace ZooDB.DataBase
{
    public class DBService
    {
        private static DBZoo dBContext = new DBZoo();
        public static List<Animal> FillAnimals()
        {
            
            List<Animal> animals = new List<Animal>();
            if (dBContext.Animals.ToList().Count != 0)
            {
                foreach (Animal animal in dBContext.Animals.ToList())
                {
                    animals.Add(animal);
                }
            }
            return animals;
        }
        public static List<Event> FillEvents()
        {
            List<Event> events = new List<Event>();
            if (dBContext.Events.ToList().Count != 0)
            {
                foreach (Event @event in dBContext.Events.ToList())
                {
                    events.Add(@event);
                }
            }
            return events;
        }
        public static List<string> GetAnimalSpecies()
        {
            List<string> species = new List<string>();
            species.Add("All");
            if (dBContext.Animals.ToList().Count != 0)
            {
                foreach (string uniqueSpecies in dBContext.Animals.ToList().Select(x => x.Species).Distinct())
                {
                    species.Add(uniqueSpecies);
                }
            }
            return species;
        }
        public static List<string> GetEventType()
        {
            List<string> types = new List<string>();
            if (dBContext.Animals.ToList().Count != 0)
            {
                foreach (string uniqueType in dBContext.Events.ToList().Select(x => x.EventType.TypeName).Distinct())
                {
                    types.Add(uniqueType);
                }
            }
            return types;
        }
        public static List<string> GetEventName()
        {
            List<string> names = new List<string>();
            if (dBContext.Animals.ToList().Count != 0)
            {
                foreach (string uniqueName in dBContext.Events.ToList().Select(x => x.Name).Distinct())
                {
                    names.Add(uniqueName);
                }
            }
            return names;
        }

        public static List<DateTime> GetEventDate()
        {
            List<DateTime> dates = new List<DateTime>();
            if (dBContext.Animals.ToList().Count != 0)
            {
                foreach (DateTime uniqueDate in dBContext.Events.ToList().Select(x => x.Date).Distinct())
                {
                    dates.Add(uniqueDate);
                }
            }
            return dates;
        }

        public static bool Login(string username, string password)
        {
            User asd = new User();
            if (dBContext.Users.ToList().Count != 0)
            {
                asd = dBContext.Users.ToList().Where(x => x.Username == username).FirstOrDefault(x => x.Password == password);
            }
            if (asd != null)
            {
                return true;
            }
            else return false;
        }
    }
}
