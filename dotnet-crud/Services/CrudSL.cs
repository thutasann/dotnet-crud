using dotnet_crud.Common.Model;
using dotnet_crud.Repositories;

namespace dotnet_crud.Services
{
	public class CrudSL : ICrudSL
	{
        public readonly ICrudRL _curdRL;
        public readonly ILogger<CrudSL> _logger;
        public readonly string EmailRegex = @"^[0-9a-zA-Z]+([._+-][0-9a-zA-Z]+)*@[0-9a-zA-Z]+.[a-zA-Z]{2,4}([.][a-zA-Z]{2,3})?$";
        public readonly string MobileRegex = @"([1-9]{1}[0-9]{9})$";
        public readonly string GenderRegex = @"^(?:m|male|f|female)$";

        public CrudSL(ICrudRL _curdRL, ILogger<CrudSL> _logger)
        {
            this._curdRL = _curdRL;
            this._logger = _logger;
        }

        public async Task<AddInformationResponse> AddInformation(AddInformationRequest request)
        {
            _logger.LogInformation("AddInformation API Calling in Service Layer...");
            return await _curdRL.AddInformation(request);
        }

        public async Task<ReadAllInformationResponse> ReadAllInformation()
        {
            _logger.LogInformation("ReadAllInformation API Calling in Service Layer...");
            return await _curdRL.ReadAllInformation();
        }

        public async Task<UpdateInformationByIDResponse> UpdateInformationByID(UpdateInformationByIDRequest request)
        {
            _logger.LogInformation("UpdateInformationByID API Calling in Service Layer");
            return await _curdRL.UpdateInformationByID(request);
        }

        public async Task<DeleteInformationByIDResponse> DeleteInformationByID(DeleteInformationByIDRequest request)
        {
            _logger.LogInformation("DeleteInformationByID calling in Service Layer");
            return await _curdRL.DeleteInformationByID(request);
        }
    }
}

