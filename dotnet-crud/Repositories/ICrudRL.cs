using dotnet_crud.Common.Model;

namespace dotnet_crud.Repositories
{
	public interface ICrudRL
	{
        /// <summary>
        /// Add Information Task
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<AddInformationResponse> AddInformation(AddInformationRequest request);

        /// <summary>
        /// Read All Information Task
        /// </summary>
        /// <returns></returns>
        public Task<ReadAllInformationResponse> ReadAllInformation();

        /// <summary>
        /// Update Information By ID Task
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<UpdateInformationByIDResponse> UpdateInformationByID(UpdateInformationByIDRequest request);

        /// <summary>
        /// Delete Information By ID Task
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public Task<DeleteInformationByIDResponse> DeleteInformationByID(DeleteInformationByIDRequest request);

        /// <summary>
        /// Get All DeleteInformation Task
        /// </summary>
        /// <returns></returns>
        public Task<GetAllDeleteInformationResponse> GetAllDeleteInformation();
    }
}

