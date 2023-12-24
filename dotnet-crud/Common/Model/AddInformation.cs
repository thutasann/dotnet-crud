namespace dotnet_crud.Common.Model
{
	/// <summary>
	/// Add Information Request Model
	/// </summary>
	public class AddInformationRequest
	{
		public string UserName { get; set; }
		public string EmailID { get; set; }
		public string MobileNumber { get; set; }
		public int Salary { get; set; }
		public string Gender { get; set; }
	}

	/// <summary>
	/// Add Information Response Model
	/// </summary>
	public class AddInformationResponse
	{
		public bool IsSuccess { get; set; }
		public string Message { get; set; }
	}
}

