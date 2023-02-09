class SQL
{
	//Publicly accessible values for database and table names
	public const string CoordinatesTB = "[CompSciNEA].[dbo].[CoordinatesTB]";
	public const string LinesTB = "[CompSciNEA].[dbo].[LinesTB]";
	public const string PaintingsTB = "[CompSciNEA].[dbo].[PaintingsTB]";
	public const string DB = "CompSciNEA";

	//Database authentication, on private!
	private const string SQLServerName = ".";
	private const string SQLServerUserName = "SQLUser";
	private const string SQLServerUserPassword = "password";

	public System.Data.DataTable ExecuteQuery(string Query, params System.Data.SqlClient.SqlParameter[] SQLParameters)
	{
		//Create connection object to SQL database
		System.Data.SqlClient.SqlConnection SQLDataBaseConnection = new System.Data.SqlClient.SqlConnection("Server=" + SQLServerName + ";Database=" + DB + ";User Id=" + SQLServerUserName + ";Password=" + SQLServerUserPassword + ";Connection Timeout=30;Connection Lifetime=0;Min Pool Size=1;Max Pool Size=1;Pooling=true;");
		System.Data.DataTable _DataTable = new System.Data.DataTable();
		try
		{
			//Open connection and set command field to given query
			SQLDataBaseConnection.Open();
			System.Data.SqlClient.SqlCommand SQLCommand = new System.Data.SqlClient.SqlCommand(Query, SQLDataBaseConnection);

			//Parameter Handling
			foreach (System.Data.SqlClient.SqlParameter CurrentParameter in SQLParameters)
			{
				SQLCommand.Parameters.Add(CurrentParameter);
			}
			//Query database, load results into _DataAdaptor
			if (Query.ToUpper().StartsWith("SELECT"))
			{
				SQLCommand.ExecuteNonQuery();
			}
			System.Data.SqlClient.SqlDataAdapter _DataAdaptor = new System.Data.SqlClient.SqlDataAdapter(SQLCommand);
			//Convert _DataAdaptor to DataTable type
			_DataAdaptor.Fill(_DataTable);
		}
		catch (System.IO.IOException _E)
		{
			//Incase of error occuring whilist performing SQL request
			throw new System.Exception("Error whilst executing SQL", _E);
		}
		finally
		{
			//Always close database, no matter the outcome of try statement
			SQLDataBaseConnection.Close();
		}
		return _DataTable;
	}
}