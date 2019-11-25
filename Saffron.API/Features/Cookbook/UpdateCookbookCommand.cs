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
	public class UpdateCookbookCommand : IRequest<Boolean>
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
	}

	public class UpdateCookbookCommandHandler : IRequestHandler<UpdateCookbookCommand, Boolean>
	{
		private readonly ApplicationDbContext _db;
		private readonly IMapper _mapper;

		public UpdateCookbookCommandHandler(ApplicationDbContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}
		public async Task<Boolean> Handle(UpdateCookbookCommand request, CancellationToken cancellationToken)
		{
			var existingCookbook = _db.Cookbooks.AsNoTracking().SingleOrDefault(c => c.Id == request.Id);
			if (existingCookbook == null)
				return false;

			existingCookbook = _mapper.Map<CookbookDAO>(request);
		
			_db.Cookbooks.Update(existingCookbook);
			await _db.SaveChangesAsync();
			return true;
		}
	}
}
