using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Saffron.API.Middleware
{
	public class GraphQLMiddleware
	{

		private readonly RequestDelegate _next;


		public GraphQLMiddleware(RequestDelegate next)
		{
			_next = next;
		}
		public async Task InvokeAsync(HttpContext context,
								 IDocumentWriter writer,
								 IDocumentExecuter executer,
								 ISchema schema)
		{
			if (context.Request.Path.StartsWithSegments("/api/graphql") &&
			  string.Equals(context.Request.Method, "POST", StringComparison.OrdinalIgnoreCase))
			{
				string body;
				using (var streamReader = new StreamReader(context.Request.Body))
				{
					body = await streamReader.ReadToEndAsync();
					var request = JsonConvert.DeserializeObject<GraphQLRequest>(body);

					var result = await executer.ExecuteAsync(doc =>
					{
						doc.Schema = schema;
						doc.Query = request.Query;

						doc.Inputs = request.Variables.ToInputs();
					}).ConfigureAwait(false);

					var json = writer.Write(result);
					await context.Response.WriteAsync(json);
				}
			}
			else
			{
				await _next(context);
			}
		}
	}
}
