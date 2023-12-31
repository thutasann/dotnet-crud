﻿using System;
using dotnet_crud.Common.Model;

namespace dotnet_crud.Services
{
	public interface ICrudSL
	{
        public Task<AddInformationResponse> AddInformation(AddInformationRequest request);
        public Task<ReadAllInformationResponse> ReadAllInformation();
        public Task<UpdateInformationByIDResponse> UpdateInformationByID(UpdateInformationByIDRequest request);
        public Task<DeleteInformationByIDResponse> DeleteInformationByID(DeleteInformationByIDRequest request);
        public Task<GetAllDeleteInformationResponse> GetAllDeleteInformation();
        public Task<DeleteAllInactiveInformationResponse> DeleteAllInActiveInformation();
        public Task<ReadInformationByIdResponse> ReadInformationByID(ReadInformationByIdRequest request);
        public Task<UpdateOneInformationByIdResponse> UpdateOneInformationById(UpdateOneInformationByIdRequest request);
    }
}

