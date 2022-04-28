using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tickets.Models;

namespace Tickets.Dto
{
    public class TicketDto
    {
        public int Id { get; set; }
        
        public string OperationType { get; set; }
        
        public Passenger passenger { get; set; }
        
        public ICollection<Route> Routes { get; set; }
        
    }
}