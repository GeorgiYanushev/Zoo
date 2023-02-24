namespace ZooDB.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using ZooDB.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ZooDB.DataBase.DBZoo>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ZooDB.DataBase.DBZoo context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.EventTypes.AddOrUpdate(
   new EventType()
   {
       TypeId = 1,
       TypeName = "Feeding"
   },
  new EventType()
  {
      TypeId = 2,
      TypeName = "Watching"
  },
  new EventType()
  {
      TypeId = 3,
      TypeName = "Safari"
  });

            context.Events.AddOrUpdate(
                new Event()
                {
                    Name = "Jaguar Watching",
                    Date = new DateTime(2006, 10, 6),
                    Cost = 15,
                    TypeId = 2

                },
                new Event()
                {
                    Name = "Elephant Feeding",
                    Date = new DateTime(2006, 10, 8),
                    Cost = 20,
                    TypeId = 1

                },
            new Event()
            {
                Name = "African Safari",
                Date = new DateTime(2006, 11, 6),
                Cost = 30,
                TypeId = 3

            },
            new Event()
            {
                Name = "Feeding the Eagles",
                Date = new DateTime(2006, 10, 6),
                Cost = 40,
                TypeId = 1

            },
            new Event()
            {
                Name = "Gorila Watching",
                Date = new DateTime(2006, 10, 6),
                Cost = 25,
                TypeId = 2

            });
            context.Animals.AddOrUpdate(
             new Animal("Bob", 7, "Jaguar", File.ReadAllBytes("AssetsDB/Jaguar.jpeg"), "Big cat"),
             new Animal("Ros", 3, "Gorila", File.ReadAllBytes("AssetsDB/Gorila.jpg"), "Largest Ape"),
             new Animal("Tweety", 2, "Eagle", File.ReadAllBytes("AssetsDB/Eagle.jfif"), "A big predatory bird"),
             new Animal("Fred", 7, "Elephant", File.ReadAllBytes("AssetsDB/Elephant.jpg"), "Largest land animal"),
             new Animal("Croc", 3, "Crocodile", File.ReadAllBytes("AssetsDB/Crocodile.jpg"), "Largest living reptile"),
             new Animal("Fredy", 8, "Jaguar", File.ReadAllBytes("AssetsDB/Jaguar.jpeg"), "Also a Big cat"));

            context.Users.AddOrUpdate(
                new User()
                {
                    Id = 1,
                    Username = "User",
                    Password = "123"

                });
        }
    }
}
