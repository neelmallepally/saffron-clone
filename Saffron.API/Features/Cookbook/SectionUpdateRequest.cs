using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saffron.API.Features.Cookbook
{
	public class SectionUpdateRequest
	{
		public string Title { get; set; }
		public int Order { get; set; }
	}
}
