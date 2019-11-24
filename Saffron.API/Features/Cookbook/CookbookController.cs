using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Saffron.API.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Saffron.API.Features.Cookbook
{
	[Route("api/cookbooks")]
	[ApiController]
	public class CookbookController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CookbookController(IMediator mediator) => _mediator = mediator;

		//public async Task<IActionResult> GetAll()
		//{
		//	var cookbookDto = await _mediator.Send<CookbookDTO>(new CookbookAllQuery());
		//}
	}

	public class CookbookDTO
	{

	}
	public class CookbookAllQuery : IRequest<CookbookDTO>
	{
	}

	public class CookbookAllQueryHandler : IRequestHandler<CookbookAllQuery, CookbookDTO>
	{
		private readonly ApplicationDbContext _context;

		public CookbookAllQueryHandler(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<CookbookDTO> Handle(CookbookAllQuery request, CancellationToken cancellationToken)
		{
			var result = new CookbookDTO();

			//TO DO: Modify this cod
			var cookbooks = await _context.Cookbooks.AsNoTracking().ToListAsync();
			return result;
		}
	}

}