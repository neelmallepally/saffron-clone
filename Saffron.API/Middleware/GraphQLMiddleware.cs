using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Saffron.API.Middleware
{
  public class GraphQLMiddleware
  {

    private readonly RequestDelegate _next;
    private readonly IDocumentExecuter _executer;
    private readonly IDocumentWriter _writer;
    private readonly ISchema _schema;

    public GraphQLMiddleware(RequestDelegate next,
                             IDocumentWriter writer,
                             IDocumentExecuter executer,
                             ISchema schema)
    {

      _next = next;
      _writer = writer;
      _executer = executer;
      _schema = schema;

    }
    public async Task InvokeAsync(HttpContext context)
    {
      if (context.Request.Path.StartsWithSegments("/api/graphql") &&
        string.Equals(context.Request.Method, "POST", StringComparison.OrdinalIgnoreCase))
      {
        string body;
        using (var streamReader = new StreamReader(context.Request.Body))
        {
          body = await streamReader.ReadToEndAsync();
          var request = JsonConvert.DeserializeObject<GraphQLRequest>(body);

          var result = await _executer.ExecuteAsync(doc =>
          {
            doc.Schema = _schema;
            doc.Query = request.Query;

            doc.Inputs = request.Variables.ToInputs();
          }).ConfigureAwait(false);

          var json = _writer.Write(result);
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
