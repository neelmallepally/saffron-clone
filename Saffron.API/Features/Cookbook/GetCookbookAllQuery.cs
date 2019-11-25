using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Saffron.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Saffron.API.Features.Cookbook
{
	public class GetCookbookAllQuery : IRequest<List<CookbookDTO>>
	{
	}
	public class GetCookbookAllQueryHandler : IRequestHandler<GetCookbookAllQuery, List<CookbookDTO>>
	{
		private readonly ApplicationDbContext _db;
		private readonly IMapper _mapper;

		public GetCookbookAllQueryHandler(ApplicationDbContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}
		public async Task<List<CookbookDTO>> Handle(GetCookbookAllQuery request, CancellationToken cancellationToken)
		{
			var cookbooks = await _db.Cookbooks.AsNoTracking().ToListAsync();
			return _mapper.Map<List<CookbookDTO>>(cookbooks); ;
		}
	}
}
