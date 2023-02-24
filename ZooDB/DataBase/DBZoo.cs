using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooDB.Models;

namespace ZooDB.DataBase
{
    public class DBZoo:DbContext
    {
        public DBZoo() : base(Properties.Settings.Default.DBconnect)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
    }
}
