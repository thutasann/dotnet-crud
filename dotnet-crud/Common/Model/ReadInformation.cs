using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dotnet_crud.Common.Model
{
	public class ReadAllInformationResponse
	{
		public bool IsSuccess { get; set; }
		public string Message { get; set; }
		public List<GetReadAllInformation> readAllInformation { get; set; }
	}

	public class GetReadAllInformation
	{
		public int UserID { get; set; }
		public string UserName { get; set; }
		public string EmailID { get; set; }
		public string MobileNumber { get; set; }
		public int Salary { get; set; }
		public string Gender { get; set; }
		public bool IsActive { get; set; }
	}


	public class ReadInformationByIdRequest
	{
		[Required]
		public int Id { get; set; }
	}

	public class ReadInformationByIdResponse
	{
		public bool IsSuccess { get; set; }
		public string Message { get; set; }
		public GetReadAllInformation readInformation { get; set; }
	}
}

