using Saffron.API.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saffron.API.Data.Models
{

	[Table("Cookbook")]
	public class CookbookDAO
	{

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }
		[Required, MaxLength(60)]
		public string Title { get; set; }
		public IEnumerable<SectionDAO> Sections { get; set; } = new List<SectionDAO>();


		public Cookbook ToDomain()
		{
			return new Cookbook
			{
				Id = Id,
				Title = Title
			};
		}

		public static CookbookDAO FromDomain(Cookbook cookbook)
		{
			return new CookbookDAO
			{
				Id = cookbook.Id,
				Title = cookbook.Title
			};
		}
	}
}
