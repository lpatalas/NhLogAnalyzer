using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhLogAnalyzer.Services;
using Xunit;

namespace NhLogAnalyzer.UnitTests.Services
{
	public class SQLiteConnectionFactoryTests
	{
		public class CreateConnectionMethod
		{
			[Fact]
			public void Should_create_specify_valid_connection_string()
			{
				// Arrange
				var connectionFactory = new SQLiteConnectionFactory();

				// Act
				var connection = connectionFactory.CreateConnection(@"X:\files.txt");
				var connectionString = connection.ConnectionString;
				connection.Dispose();

				// Assert
				Assert.Equal(@"Data Source=X:\files.txt;Version=3", connectionString);
			}
		}
	}
}
