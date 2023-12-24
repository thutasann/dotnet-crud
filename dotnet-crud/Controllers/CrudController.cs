using dotnet_crud.Common.Model;
using dotnet_crud.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_crud.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        public readonly ICrudSL _crudSL;

        public CrudController(ICrudSL _crudSL)
        {
            this._crudSL = _crudSL;
        }

        [HttpPost]
        public async Task<IActionResult> AddInformation(AddInformationRequest addInformationRequest)
        {
            AddInformationResponse response = new();

            try
            {
                response = await _crudSL.AddInformation(addInformationRequest);
            }
            catch(Exception e)
            {
                response.IsSuccess = false;
                response.Message = "From Controller " + e.Message;
            }

            return Ok(response);
        }

    }
}

