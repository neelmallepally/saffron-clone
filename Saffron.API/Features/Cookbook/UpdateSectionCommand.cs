using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Saffron.API.Data;
using Saffron.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Saffron.API.Features.Cookbook
{
	public class UpdateSectionCommand : IRequest<bool>
	{
		public int Order { get; set; }
		public string Title { get; set; }
		public Guid SectionId { get; set; }
	}

	public class UpdateSectionCommandHandler : IRequestHandler<UpdateSectionCommand, bool>
	{
		private readonly ApplicationDbContext _db;
		private readonly IMapper _mapper;

		public UpdateSectionCommandHandler(ApplicationDbContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}
		public async Task<bool> Handle(UpdateSectionCommand request, CancellationToken cancellationToken)
		{
			var section = await _db.Sections.AsNoTracking().SingleOrDefaultAsync(s => s.Id == request.SectionId);
			if (section == null)
				return false;

			section = _mapper.Map<SectionDAO>(request);
			_db.Sections.Update(section);
			await _db.SaveChangesAsync();
			return true;
		}
	}
}
