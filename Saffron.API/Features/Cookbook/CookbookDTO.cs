using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Saffron.API.Features.Cookbook
{
	public class CookbookDTO
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
	}
}
