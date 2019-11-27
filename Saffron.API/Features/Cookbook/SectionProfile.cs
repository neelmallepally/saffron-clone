using AutoMapper;
using Saffron.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saffron.API.Features.Cookbook
{
	public class SectionProfile : Profile
	{
		public SectionProfile()
		{
			CreateMap<SectionDAO, SectionDTO>();
			CreateMap<SectionUpdateRequest, UpdateSectionCommand>();
			CreateMap<UpdateSectionCommand, SectionDAO>();
		}
	}
}
