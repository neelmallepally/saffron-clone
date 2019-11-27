using AutoMapper;
using Dapper;
using MediatR;
using Saffron.API.Data;
using Saffron.API.Data.Models;
using Saffron.API.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Saffron.API.Features.Cookbook
{
	public class GetCookbookSectionDetailsQuery : IRequest<SectionDTO>
	{
		public Guid SectionId { get; set; }
	}

	public class GetCookbookSectionDetailsQueryHandler : IRequestHandler<GetCookbookSectionDetailsQuery, SectionDTO>
	{
		private readonly ISqlConnectionFactory _sqlConnectionFactory;
		private readonly IMapper _mapper;

		public GetCookbookSectionDetailsQueryHandler(ISqlConnectionFactory db, IMapper mapper)
		{
			_sqlConnectionFactory = db;
			_mapper = mapper;
		}
		public async Task<SectionDTO> Handle(GetCookbookSectionDetailsQuery request, CancellationToken cancellationToken)
		{
			var connection = _sqlConnectionFactory.GetOpenConnection();
			const string sql = @"SELECT Id, Title FROM Sections WHERE Id = @SectionId";
			var section = await connection.QueryAsync<SectionDAO>(sql, new { SectionId = request.SectionId });
			return _mapper.Map<SectionDTO>(section);
		}
	}
}
