using System;
using System.Collections.Generic;

#nullable disable

namespace Tickets
{
    public partial class Segment
    {
        public int Id { get; set; }
        public string OperationType { get; set; }
        public string Name { get; set; }
        public long TicketNumber { get; set; }
        public string DepartPlace { get; set; }
        public DateTime DepartTime { get; set; }
        public string ArrivePlace { get; set; }
        public DateTime ArriveTime { get; set; }
    }
}
