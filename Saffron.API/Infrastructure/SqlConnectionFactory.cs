using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Saffron.API.Infrastructure
{
	public interface ISqlConnectionFactory
	{
		IDbConnection GetOpenConnection();
	}
	public class SqlConnectionFactory : ISqlConnectionFactory, IDisposable
	{
		private readonly string _connectionString;
		private IDbConnection _connection;

		public SqlConnectionFactory(string connectionString)
		{
			this._connectionString = connectionString;
		}

		public IDbConnection GetOpenConnection()
		{
			if (this._connection == null || this._connection.State != ConnectionState.Open)
			{
				this._connection = new SqlConnection(_connectionString);
				this._connection.Open();
			}

			return this._connection;
		}

		public void Dispose()
		{
			if (this._connection != null && this._connection.State == ConnectionState.Open)
			{
				this._connection.Dispose();
			}
		}
	}
}
