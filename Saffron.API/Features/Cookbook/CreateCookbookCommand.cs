using AutoMapper;
using MediatR;
using Saffron.API.Data;
using Saffron.API.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Saffron.API.Features.Cookbook
{
	public class CreateCookbookCommand : IRequest<CookbookDTO>
	{
		[Required(ErrorMessage = "Title for cookbook is required")]
		[StringLength(60, ErrorMessage = "Title cannot be longer than 60 characters")]
		public string Title { get; set; }
	}

	public class CreateCookbookCommandHandler : IRequestHandler<CreateCookbookCommand, CookbookDTO>
	{
		private readonly ApplicationDbContext _db;
		private readonly IMapper _mapper;

		public CreateCookbookCommandHandler(ApplicationDbContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}
		public async Task<CookbookDTO> Handle(CreateCookbookCommand request, CancellationToken cancellationToken)
		{
			var cookbookDAO = _mapper.Map<CookbookDAO>(request);
			 _db.Cookbooks.Add(cookbookDAO);
			await _db.SaveChangesAsync();
			return _mapper.Map<CookbookDTO>(cookbookDAO); ;
		}
	}
}
