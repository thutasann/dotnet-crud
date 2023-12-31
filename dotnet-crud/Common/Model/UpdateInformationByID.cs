﻿using System;
using System.ComponentModel.DataAnnotations;

namespace dotnet_crud.Common.Model
{
	public class UpdateInformationByIDRequest
	{
        [Required(ErrorMessage = "UserId is Required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "UserName Is Mandetory Field")]
        public string UserName { get; set; }

        [Required]
        [RegularExpression("^[0-9a-zA-Z]+([._+-][0-9a-zA-Z]+)*@[0-9a-zA-Z]+.[a-zA-Z]{2,4}([.][a-zA-Z]{2,3})?$", ErrorMessage = "Email Id Not In Currect Formate Example : VishalTechnology@gmail.com")]
        public string EmailID { get; set; }

        [Required]
        [RegularExpression("^([1-9]{1}[0-9]{9})$", ErrorMessage = "Mobile Number Not In Currect Formate")]
        public string MobileNumber { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a Salary Greater than 0")]
        public int Salary { get; set; }

        [Required]
        [RegularExpression("^(?:m|male|f|female)$", ErrorMessage = "Not valid Gender eg : m, f, Male Or Female")]
        public string Gender { get; set; }
    }

	public class UpdateInformationByIDResponse
	{
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    /// <summary>
    /// Update One Information By ID
    /// </summary>
    public class UpdateOneInformationByIdRequest
    {
        [Required(ErrorMessage = "UserId is Required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Salary Is Required")]
        public int Salary { get; set; }
    }

    public class UpdateOneInformationByIdResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}

