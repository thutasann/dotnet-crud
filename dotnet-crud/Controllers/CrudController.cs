﻿using dotnet_crud.Common.Model;
using dotnet_crud.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_crud.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        public readonly ICrudSL _crudSL;
        public readonly ILogger<CrudController> _logger;

        public CrudController(ICrudSL _crudSL, ILogger<CrudController> _logger)
        {
            this._crudSL = _crudSL;
            this._logger = _logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddInformation(AddInformationRequest addInformationRequest)
        {
            AddInformationResponse response = new();
            _logger.LogInformation($"AddInformation API Calling in Controller...");

            try
            {
                response = await _crudSL.AddInformation(addInformationRequest);

                if(!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
                }
            }
            catch(Exception e)
            {
                response.IsSuccess = false;
                response.Message = "From Controller " + e.Message;
                _logger.LogError("AddInfomration API Error ", e.Message);
                return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
            }

            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message });
        }

        [HttpGet]
        public async Task<IActionResult> ReadAllInformations()
        {
            ReadAllInformationResponse response = new();
            _logger.LogInformation("ReadAllInformations Calling in Controller...");
            try
            {
                response = await _crudSL.ReadAllInformation();

                if(!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message, Data = response });
                }
            }
            catch(Exception e)
            {
                response.IsSuccess = false;
                response.Message = "From Controller " + e.Message;
                _logger.LogError("ReadAllInformations Error ", e.Message);
            }
            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message, Data = response.readAllInformation });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateInformationByID(UpdateInformationByIDRequest request)
        {
            UpdateInformationByIDResponse response = new();
            _logger.LogInformation("UpdateInformationByID in Controller...");

            try
            {
                response = await _crudSL.UpdateInformationByID(request);

                if(!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
                }
            }
            catch(Exception e)
            {
                response.IsSuccess = false;
                response.Message = "UpdateInformationByID Error " + e.Message;
                _logger.LogError("UpdateInformationByID Error ", e.Message);
                return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
            }

            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteInformationByID(DeleteInformationByIDRequest request)
        {
            DeleteInformationByIDResponse response = new();
            _logger.LogInformation("DeleteInformationByID in Controller...");

            try
            {
                response = await _crudSL.DeleteInformationByID(request);

                if (!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
                }
            }
            catch(Exception e)
            {
                response.IsSuccess = false;
                response.Message = "DeleteInformationByID Error " + e.Message;
                _logger.LogError("DeleteInformationByID Error ", e.Message);
                return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
            }

            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message });
        }

        [HttpPost]
        public async Task<IActionResult> GetAllDeleteInformation()
        {
            GetAllDeleteInformationResponse response = new();
            _logger.LogInformation("DeleteAllInformation API Calling");
            try
            {
                response = await _crudSL.GetAllDeleteInformation();

                if(!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
                }
            }
            catch(Exception e)
            {
                response.IsSuccess = false;
                response.Message = e.Message;
                _logger.LogError("DeleteAllInformation Controller Error", e.Message);
            }
            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message, Data = response.deletedInformation });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAllInActiveInformation()
        {
            DeleteAllInactiveInformationResponse response = new()
            {
                IsSuccess = true,
                Message = "Successful"
            };
            _logger.LogInformation("DeleteAllInActiveInformation API Calling");

            try
            {
                response = await _crudSL.DeleteAllInActiveInformation();

                if(!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
                }
            }
            catch(Exception e)
            {
                response.IsSuccess = false;
                response.Message = e.Message;
            }

            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message });
        }

        [HttpPost]
        public async Task<IActionResult> ReadInformationByID(ReadInformationByIdRequest request)
        {
            _logger.LogInformation("ReadInformationByID API Calling");
            ReadInformationByIdResponse response = new();
            try
            {
                response = await _crudSL.ReadInformationByID(request);

                if(!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
                }
            }
            catch(Exception e)
            {
                response.IsSuccess = false;
                response.Message = e.Message;

            }
            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message, Data = response.readInformation });
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateOneInformationById(UpdateOneInformationByIdRequest request)
        {
            _logger.LogInformation("UpdateOneInformationById API Calling");
            UpdateOneInformationByIdResponse response = new();
            try
            {
                response = await _crudSL.UpdateOneInformationById(request);
                if(!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
                }
            }
            catch(Exception e)
            {
                response.IsSuccess = false;
                response.Message = "Update One Information Error " + e.Message;
                _logger.LogError($"Update One Information By ID Error ${e.Message}");
                return BadRequest(new { IsSuccess = response.IsSuccess, Message = e.Message });
            }
            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message });
        }
    }
}

