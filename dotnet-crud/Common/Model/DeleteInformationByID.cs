using System;
using System.ComponentModel.DataAnnotations;


namespace dotnet_crud.Common.Model
{
	public class DeleteInformationByIDRequest
	{
		[Required(ErrorMessage = "UserID is required")]
		public int UserId { get; set; }
	}

	public class DeleteInformationByIDResponse
	{
		public bool IsSuccess { get; set; }
		public string Message { get; set; }
	}

	public class DeleteAllInformationResponse
	{
		public bool IsSuccess { get; set; }
		public string Message { get; set; }
		public List<DeletedInformation> deletedInformation { get; set; }
	}

	public class DeletedInformation
	{
		public int UserId { get; set; }
		public string UserName { get; set; }
		public string EmailId { get; set; }
		public string MobileNumber { get; set; }
		public int Salary { get; set; }
		public string Gender { get; set; }
		public bool IsActive { get; set; }
	}

	public class GetAllDeleteInformationResponse
	{
		public bool IsSuccess { get; set; }
		public string Message { get; set; }
		public List<DeletedInformation> deletedInformation { get; set; }
	}
}

