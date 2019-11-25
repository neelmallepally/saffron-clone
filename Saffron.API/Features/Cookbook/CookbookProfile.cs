using AutoMapper;
using Saffron.API.Data.Models;
using Saffron.API.Features.Cookbook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saffron.API.Features.Cookbook
{
	public class CookbookProfile : Profile
	{
		public CookbookProfile()
		{
			CreateMap<CookbookDAO, CookbookDTO>();
			CreateMap<CreateCookbookCommand, CookbookDAO>();
			CreateMap<UpdateCookbookCommand, CookbookDAO>();
		}
	}
}
