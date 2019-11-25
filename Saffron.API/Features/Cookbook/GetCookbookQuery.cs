using AutoMapper;
using MediatR;
using Saffron.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Saffron.API.Features.Cookbook
{
	public class GetCookbookQuery : IRequest<CookbookDTO>
	{
		public Guid Id { get; set; }
	}

	public class GetCookbookQueryHandler : IRequestHandler<GetCookbookQuery, CookbookDTO>
	{
		private readonly ApplicationDbContext _db;
		private readonly IMapper _mapper;

		public GetCookbookQueryHandler(ApplicationDbContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}
		public async Task<CookbookDTO> Handle(GetCookbookQuery request, CancellationToken cancellationToken)
		{
			var cookbook = await _db.Cookbooks.FindAsync(request.Id);
			return _mapper.Map<CookbookDTO>(cookbook);
		}
	}
}
