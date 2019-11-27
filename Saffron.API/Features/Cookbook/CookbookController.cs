using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Saffron.API.Data;
using System;
using System.Collections.Generic;
using static Microsoft.AspNetCore.Http.StatusCodes;
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
		[ProducesResponseType(typeof(List<CookbookDTO>), Status200OK)]
		public async Task<ActionResult<List<CookbookDTO>>> GetAll() => await _mediator.Send(new GetCookbookAllQuery());

		[HttpGet("{id}", Name = "CookbookById")]
		[ProducesResponseType(typeof(CookbookDTO), Status200OK)]
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
		[ProducesResponseType(typeof(CookbookDTO), Status201Created)]
		public async Task<IActionResult> Create([FromBody]CreateCookbookCommand cookbook)
		{
			var result = await _mediator.Send(cookbook);
			return CreatedAtRoute("CookbookById", new { id = result.Id }, result);
		}

		[HttpPatch("{id}")]
		[ProducesResponseType(Status200OK)]
		public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody]UpdateCookbookCommand request)
		{
			if (id != request.Id)
			{
				return BadRequest($"ID {id} does not match with request ID {request.Id}");
			}
			var result = await _mediator.Send(request);
			if (result)
				return Ok();

			return BadRequest($"Cookbook with ID {id} not found");
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(Status200OK)]
		public async Task<IActionResult> Delete([FromRoute]Guid id)
		{
			await _mediator.Send(new DeleteCookbookCommand() { Id = id });
			return Ok();
		}

		// cookbook sections. Ex: Breakfast, Morning Snacks, Lunch etc
		[HttpGet("{cookbookId}/sections")]
		[ProducesResponseType(typeof(List<SectionDTO>), Status200OK)]
		public async Task<IActionResult> GetSections([FromRoute]Guid cookbookId)
		{
			var sections = await _mediator.Send(new GetCookbookSectionsQuery() { CookbookId = cookbookId });
			return Ok(sections);
		}

		[HttpGet("{cookbookId}/sections/{sectionId}")]
		[ProducesResponseType(typeof(List<SectionDTO>), Status200OK)]
		public async Task<IActionResult> GetSection([FromRoute]Guid sectionId)
		{
			var sections = await _mediator.Send(new GetCookbookSectionDetailsQuery() { SectionId = sectionId });
			return Ok(sections);
		}

		[HttpPost("{cookbookId}/sections")]
		[ProducesResponseType(Status201Created)]
		public async Task<IActionResult> CreateSection([FromRoute]Guid cookbookId, [FromBody]SectionCreateRequest request)
		{
			await _mediator.Send(new CreateSectionCommand
			{
				Title = request.Title,
				CookbookId = cookbookId,
				Order = request.Order
			});
			return Created(string.Empty, null);
		}

		[HttpPatch("{cookbookId}/sections/{sectionId}")]
		[ProducesResponseType(Status200OK)]
		public async Task<IActionResult> UpdateSection([FromRoute]Guid sectionId, [FromBody]SectionUpdateRequest request)
		{
			var result = await _mediator.Send(new UpdateSectionCommand()
			{
				Title = request.Title,
				Order = request.Order,
				SectionId = sectionId
			});

			if(result)
			{
				return Ok();
			}
			return BadRequest($"Section with ID {sectionId} not found");
		}

		[HttpDelete("{cookbookId}/sections/{sectionId}")]
		[ProducesResponseType(Status200OK)]
		public async Task<IActionResult> DeleteSection([FromRoute]Guid sectionId)
		{
			await _mediator.Send(new DeleteSectionCommand() { SectionId = sectionId });
			return Ok();
		}

	}
}