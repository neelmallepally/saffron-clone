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
	public class DeleteSectionCommand : IRequest
	{
		public Guid SectionId { get; set; }
	}

	public class DeleteSectionCommandHandler : IRequestHandler<DeleteSectionCommand>
	{
		private readonly ApplicationDbContext _db;
		public DeleteSectionCommandHandler(ApplicationDbContext db)
		{
			_db = db;
		}
		public async Task<Unit> Handle(DeleteSectionCommand request, CancellationToken cancellationToken)
		{
			var section = await _db.Sections.AsNoTracking().SingleOrDefaultAsync(s => s.Id == request.SectionId);
			if(section !=null)
			{
				_db.Sections.Remove(section);
				await _db.SaveChangesAsync();
			}
			return Unit.Value;
		}
	}
}
