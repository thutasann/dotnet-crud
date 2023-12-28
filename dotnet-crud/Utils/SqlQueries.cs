namespace dotnet_crud.Utils
{
	public class SqlQueries
	{
        public static IConfiguration _sqlQueryConfiguration = new ConfigurationBuilder()
           .AddXmlFile("SqlQueries.xml", true, true)
           .Build();

        public static string AddInformation { get { return _sqlQueryConfiguration["AddInformation"]; } }

        public static string ReadAllInformation { get { return _sqlQueryConfiguration["ReadAllInformation"]; } }

        public static string UpdateInformationByID { get { return _sqlQueryConfiguration["UpdateInformationByID"]; } }

        public static string DeleteInformationByID { get { return _sqlQueryConfiguration["DeleteInformationByID"]; } }

        public static string GetAllDeleteInformation { get { return _sqlQueryConfiguration["GetAllDeleteInformation"]; } }

    }
}

