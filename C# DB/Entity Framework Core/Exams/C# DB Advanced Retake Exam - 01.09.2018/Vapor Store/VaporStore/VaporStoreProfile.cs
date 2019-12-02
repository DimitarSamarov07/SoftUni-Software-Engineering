﻿namespace VaporStore
{
	using AutoMapper;
    using Data.Models;
    using DataProcessor.ImportDtos;

    public class VaporStoreProfile : Profile
	{
		// Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
		public VaporStoreProfile()
        {
            this.CreateMap<ImportUserCardsDto, User>();
            this.CreateMap<ImportCardDto, Card>();
        }
	}
}