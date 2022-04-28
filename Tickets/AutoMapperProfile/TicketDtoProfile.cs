using AutoMapper;
using Tickets.Dto;
using Tickets.Models;

namespace Tickets.AutoMapperProfile
{
    public class TicketDtoProfile:Profile
    {
        public TicketDtoProfile()
        {
            CreateMap<Ticket, TicketDto>().ReverseMap();
        }
    }
}