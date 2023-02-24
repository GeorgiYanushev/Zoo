using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooDB.Models
{
    public class EventType
    {
        [Key]
        public int TypeId { get; set; }

        public string TypeName { get; set; }
    }
}
