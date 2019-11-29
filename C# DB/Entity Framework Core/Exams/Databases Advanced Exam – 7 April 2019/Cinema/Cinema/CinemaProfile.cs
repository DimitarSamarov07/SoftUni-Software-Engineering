using AutoMapper;

namespace Cinema
{
    using Data.Models;
    using DataProcessor.ImportDto;

    public class CinemaProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public CinemaProfile()
        {
            this.CreateMap<ImportMovieDto, Movie>();
            this.CreateMap<ImportHallSeatsDto, Hall>();
            this.CreateMap<ImportProjectionDto, Projection>();
            this.CreateMap<ImportCustomerTicketsDto, Customer>();
            this.CreateMap<ImportTicketDto, Ticket>();
        }
    }
}
