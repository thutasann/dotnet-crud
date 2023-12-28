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
}

