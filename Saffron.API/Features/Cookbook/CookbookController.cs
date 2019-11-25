using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Saffron.API.Data;
using System;
using System.Collections.Generic;
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

		[HttpGet]
		public async Task<ActionResult<List<CookbookDTO>>> GetAll() => await _mediator.Send(new GetCookbookAllQuery());

		[HttpGet("{id}", Name = "CookbookById")]
		public async Task<ActionResult<CookbookDTO>> Get(Guid id)
		{
			var cookbook = await _mediator.Send(new GetCookbookQuery { Id = id });
			if (cookbook != null)
			{
				return cookbook;
			}
			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody]CreateCookbookCommand cookbook)
		{
			var result = await _mediator.Send(cookbook);
			return CreatedAtRoute("CookbookById", new { id = result.Id }, result);
		}

		[HttpPatch("{id}")]
		public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody]UpdateCookbookCommand request)
		{
			if(id != request.Id)
			{
				return BadRequest($"ID {id} does not match with request ID {request.Id}");
			}
			var result = await _mediator.Send(request);
			if (result)
				return NoContent();

			return BadRequest($"Cookbook with ID {id} not found");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute]Guid id)
		{
			await _mediator.Send(new DeleteCookbookCommand() { Id = id });
			return NoContent();
		}
	}
}