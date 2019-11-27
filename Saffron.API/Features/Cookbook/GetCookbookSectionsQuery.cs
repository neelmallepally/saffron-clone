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
	public class GetCookbookSectionsQuery : IRequest<IEnumerable<SectionDTO>>
	{
		public Guid CookbookId { get; set; }
	}

	public class GetCookbookSectionsQueryHandler : IRequestHandler<GetCookbookSectionsQuery, IEnumerable<SectionDTO>>
	{
		private readonly ApplicationDbContext _db;
		private readonly IMapper _mapper;

		public GetCookbookSectionsQueryHandler(ApplicationDbContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}
		public async Task<IEnumerable<SectionDTO>> Handle(GetCookbookSectionsQuery request, CancellationToken cancellationToken)
		{
			var cookbook = await _db.Cookbooks.AsNoTracking()
				.Include(c => c.Sections)
				.Where(c => c.Id == request.CookbookId)
				.SingleOrDefaultAsync();

			if(cookbook == null)
			{
				//TO DO: Instead of throwing error, tell client that Cookbook does not exist
				throw new Exception("Cookbook does not exists");
			}

			return _mapper.Map<IEnumerable<SectionDTO>>(cookbook.Sections);
		}
	}
}
