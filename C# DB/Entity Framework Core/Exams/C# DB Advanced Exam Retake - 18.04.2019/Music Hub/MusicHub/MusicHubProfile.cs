namespace MusicHub
{
    using AutoMapper;
    using Data.Models;
    using DataProcessor.ImportDtos;

    public class MusicHubProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public MusicHubProfile()
        {
            this.CreateMap<ImportWriterDto, Writer>();
            this.CreateMap<ImportProducerAlbumsDto, Producer>();
            this.CreateMap<ImportAlbumDto, Album>();
            this.CreateMap<ImportSongDto, Song>();
        }
    }
}
