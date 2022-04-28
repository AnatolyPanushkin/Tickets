using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tickets.AutoMapperProfile;
using Tickets.Dto;
using Tickets.Models;


namespace Tickets.Controllers
{
    [ApiController]
    [Route("process/sale")]
    public class ApiControllers: ControllerBase
    {
        private readonly TicketContext _context;
       //private readonly IMapper _mapper;

        public ApiControllers(TicketContext context)
        {
            _context = context;
            //_mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _context.Segments.FirstOrDefault(m => m.Id == id);
            return Ok(result);
        }

        [HttpPost]
        public void SaleTicket(Ticket ticket)
        {
            Segment segment = new Segment();
            for (int i = 0; i < ticket.Routes.Length; i++)
            {
                segment.Id = ticket.Id;
                segment.Name = ticket.Passenger.Name;
                segment.TicketNumber = ticket.Passenger.TicketNumber;
                segment.OperationType = ticket.OperationType;
                segment.DepartPlace = ticket.Routes[i].DepartPlace;
                segment.DepartTime = ticket.Routes[i].DepartTime;
                segment.ArrivePlace = ticket.Routes[i].ArrivePlace;
                segment.ArriveTime = ticket.Routes[i].ArriveTime;
                
                _context.Segments.Add(segment);
                _context.SaveChanges();
            }
               
        }
    }
}