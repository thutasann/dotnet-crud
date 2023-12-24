namespace dotnet_crud.Utils
{
	public class SqlQueries
	{
		public static IConfiguration _configuration = new ConfigurationBuilder().AddXmlFile("SqlQueries.xml", true, true).Build();

		public static string AddInformation { get { return _configuration["AddInformation"]; } }
	}
}

