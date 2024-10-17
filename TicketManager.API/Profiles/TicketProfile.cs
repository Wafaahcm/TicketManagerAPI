using static System.Runtime.InteropServices.JavaScript.JSType;
using TicketManager.API.Entities;
using TicketManager.API.Models;
using AutoMapper;

namespace TicketManager.API.Profiles
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<Ticket, TicketDto>();
            CreateMap<TicketForCreationDto, Ticket>();
            CreateMap<TicketForUpdateDto, Ticket>();
        }
    }
}
