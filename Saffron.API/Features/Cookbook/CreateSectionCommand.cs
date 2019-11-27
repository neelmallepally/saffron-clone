using MediatR;
using Saffron.API.Data;
using Saffron.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Saffron.API.Features.Cookbook
{
	public class CreateSectionCommand : IRequest<Unit>
	{
		public string Title { get; set; }
		public Guid CookbookId { get; set; }
		public int Order { get; set; }
	}

	public class CreateSectionCommandHandler : IRequestHandler<CreateSectionCommand, Unit>
	{
		private readonly ApplicationDbContext _db;
		public CreateSectionCommandHandler(ApplicationDbContext db)
		{
			_db = db;
		}
		public async Task<Unit> Handle(CreateSectionCommand request, CancellationToken cancellationToken)
		{
			var section = new SectionDAO()
			{
				Title = request.Title,
				CookbookId = request.CookbookId,
				Order = request.Order
			};
			_db.Sections.Add(section);
			await _db.SaveChangesAsync();
			return Unit.Value;
		}
	}
}
