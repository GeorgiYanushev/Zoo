using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooDB.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Cost { get; set; }
        public Event(string name, DateTime date, string type, int cost)
        {
            Name = name;
            Date = date;
            Cost = cost;
        }

        public Event()
        {
        }

        [ForeignKey(nameof(EventType))]
        public int TypeId { get; set; }
        public virtual EventType EventType { get; set; }
    }
}
