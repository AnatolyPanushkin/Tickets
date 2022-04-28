using System;
using System.Collections.Generic;

namespace Tickets.Models
{

    public class Ticket
    {
        public int Id { get; set; }
        
        public string OperationType { get; set; }
        
        public Passenger Passenger  { get; set; }
        
        public Route[] Routes { get; set; }
    }
}