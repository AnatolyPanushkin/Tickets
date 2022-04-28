using System;
using System.ComponentModel.DataAnnotations;

namespace Tickets.Models
{
    public class Route
    {
        public string DepartPlace { get; set; }
        
        public DateTime DepartTime { get; set; }
        
        public string ArrivePlace { get; set; }
        public DateTime ArriveTime { get; set; }
    }
}