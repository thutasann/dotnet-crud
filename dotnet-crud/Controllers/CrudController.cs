using Microsoft.AspNetCore.Mvc;
using dotnet_crud.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnet_crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CrudController : ControllerBase
    {
        public readonly ICrudSL _crudSL;

        public CrudController(ICrudSL _crudSL)
        {
            this._crudSL = _crudSL;
        }

        [HttpPost]
        public IActionResult AddInformation()
        {
            return Ok();
        }

    }
}

