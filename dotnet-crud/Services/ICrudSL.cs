using System;
using dotnet_crud.Common.Model;

namespace dotnet_crud.Services
{
	public interface ICrudSL
	{
        public Task<AddInformationResponse> AddInformation(AddInformationRequest request);
        public Task<ReadAllInformationResponse> ReadAllInformation();
    }
}

