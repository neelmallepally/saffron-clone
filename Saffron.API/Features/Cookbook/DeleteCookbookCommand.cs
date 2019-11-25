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
	public class DeleteCookbookCommand : IRequest<Unit>
	{
		public Guid Id { get; set; }
	}

	public class DeleteCookbookCommandHandler : IRequestHandler<DeleteCookbookCommand, Unit>
	{
		private readonly ApplicationDbContext _db;
		private readonly IMapper _mapper;

		public DeleteCookbookCommandHandler(ApplicationDbContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}
		public async Task<Unit> Handle(DeleteCookbookCommand request, CancellationToken cancellationToken)
		{
			var cookbook = _db.Cookbooks.AsNoTracking().SingleOrDefault(c => c.Id == request.Id);
			if(cookbook != null)
			{
				_db.Cookbooks.Remove(cookbook);
				await _db.SaveChangesAsync();
			}
			return Unit.Value;
		}
	}
}
