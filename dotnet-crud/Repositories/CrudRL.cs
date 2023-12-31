using dotnet_crud.Common.Model;
using dotnet_crud.Utils;
using MySqlConnector;

namespace dotnet_crud.Repositories
{
    public class CrudRL : ICrudRL
    {
        public readonly IConfiguration _configuration;
        public readonly MySqlConnection _mySqlConnection;
        public readonly ILogger<CrudRL> _logger;

        public CrudRL(IConfiguration _configuration, ILogger<CrudRL> _logger)
        {
            this._configuration = _configuration;
            this._logger = _logger;
            _mySqlConnection = new MySqlConnection(_configuration["ConnectionStrings:MySqlDBConnection"]);
        }


        public async Task<AddInformationResponse> AddInformation(AddInformationRequest request)
        {

            _logger.LogInformation("Add Information Repository Layer Calling");

            AddInformationResponse response = new()
            {
                IsSuccess = true,
                Message = "Successful"
            };

            try
            {
                if(_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                using (MySqlCommand sqlCommand = new(SqlQueries.AddInformation, _mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@UserName", request.UserName);
                    sqlCommand.Parameters.AddWithValue("@EmailID", request.EmailID);
                    sqlCommand.Parameters.AddWithValue("@MobileNumber", request.MobileNumber);
                    sqlCommand.Parameters.AddWithValue("@Salary", request.Salary);
                    sqlCommand.Parameters.AddWithValue("@Gender", request.Gender);

                    int Status = await sqlCommand.ExecuteNonQueryAsync();
                    if (Status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "AddInformation Query Not Executed";
                        _logger.LogError("AddInformation Query Not Executed");
                    }
                }
            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.Message = "From Repository " + e.Message;
                _logger.LogError("AddInformation Error in RL", e.Message);
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }
            return response;

        }

        public async Task<ReadAllInformationResponse> ReadAllInformation()
        {
            _logger.LogInformation("Read All Information Repository Layer Calling");

            ReadAllInformationResponse response = new() {
                IsSuccess = true,
                Message = "Successful"
            };

            try
            {
                if(_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                using(MySqlCommand sqlCommand = new(SqlQueries.ReadAllInformation, _mySqlConnection))
                {
                    try
                    {
                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        sqlCommand.CommandTimeout = 180;

                        using(MySqlDataReader dataReader = await sqlCommand.ExecuteReaderAsync())
                        {
                            if(dataReader.HasRows)
                            {
                                response.readAllInformation = new List<GetReadAllInformation>();

                                while(await dataReader.ReadAsync())
                                {
                                    GetReadAllInformation getData = new()
                                    {
                                        UserID = dataReader["UserId"] != DBNull.Value ? Convert.ToInt32(dataReader["UserId"]) : 0,
                                        UserName = dataReader["UserName"] != DBNull.Value ? Convert.ToString(dataReader["UserName"]) : string.Empty,
                                        EmailID = dataReader["EmailID"] != DBNull.Value ? Convert.ToString(dataReader["EmailID"]) : string.Empty,
                                        Salary = dataReader["Salary"] != DBNull.Value ? Convert.ToInt32(dataReader["Salary"]) : 0,
                                        MobileNumber = dataReader["MobileNumber"] != DBNull.Value ? Convert.ToString(dataReader["MobileNumber"]) : string.Empty,
                                        Gender = dataReader["Gender"] != DBNull.Value ? Convert.ToString(dataReader["Gender"]) : string.Empty,
                                        IsActive = dataReader["IsActive"] != DBNull.Value ? Convert.ToBoolean(dataReader["IsActive"]) : false
                                    };
                                    response.readAllInformation.Add(getData);
                                }
                            }
                            else
                            {
                                response.IsSuccess = true;
                                response.Message = "Record Not Found / Database Empty";
                            }
                        }
                    }
                    catch(Exception e)
                    {
                        response.IsSuccess = false;
                        response.Message = "From using MysqlCommand " + e.Message;
                        _logger.LogError("GetllAllInformation Error Occur: Message " + e.Message);
                    }
                    finally
                    {
                        await _mySqlConnection.DisposeAsync();
                    }
                }
            }
            catch(Exception e)
            {
                response.IsSuccess = false;
                response.Message = "From Respository " + e.Message;
                _logger.LogError("ReadAllInformation Error in RL" + e.Message);
            }
            finally {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }
            return response;
        }

        public async Task<UpdateInformationByIDResponse> UpdateInformationByID(UpdateInformationByIDRequest request)
        {
            _logger.LogInformation("Update Information By ID Repository Layer Calling");
            UpdateInformationByIDResponse response = new()
            {
                IsSuccess = true,
                Message = "Successful!"
            };

            try
            {
                if(_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                using (MySqlCommand sqlCommand = new(SqlQueries.UpdateInformationByID, _mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@UserId", request.UserId);
                    sqlCommand.Parameters.AddWithValue("@UserName", request.UserName);
                    sqlCommand.Parameters.AddWithValue("@EmailID", request.EmailID);
                    sqlCommand.Parameters.AddWithValue("@MobileNumber", request.MobileNumber);
                    sqlCommand.Parameters.AddWithValue("@Salary", request.Salary);
                    sqlCommand.Parameters.AddWithValue("@Gender", request.Gender);

                    int Status = await sqlCommand.ExecuteNonQueryAsync();
                    if (Status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "UpdateInformationByID Query Not Executed";
                        _logger.LogError("UpdateInformationByID Query Not Executed");
                    }
                }
            }
            catch(Exception e)
            {
                response.IsSuccess = false;
                response.Message = "From Repository " + e.Message;
                _logger.LogError("UpdateInformation Error in RL ", e.Message);
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }
            return response;
        }

        public async Task<DeleteInformationByIDResponse> DeleteInformationByID(DeleteInformationByIDRequest request)
        {
            _logger.LogInformation("Delete Information By ID Repository Layer Calling");

            DeleteInformationByIDResponse response = new()
            {
                IsSuccess = true,
                Message = "Successful"
            };

            try
            {
                if(_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                using (MySqlCommand sqlCommand = new(SqlQueries.DeleteInformationByID, _mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@UserId", request.UserId);
                    int Status = await sqlCommand.ExecuteNonQueryAsync();
                    if(Status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Query Not Executed";
                        _logger.LogError("Error Occured: Delete Query Not Executed");
                        return response;
                    }
                }

            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.Message = "From Repository " + e.Message;
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }
            return response;

        }

        public async Task<GetAllDeleteInformationResponse> GetAllDeleteInformation()
        {
            _logger.LogInformation("GetAllDeleteInformation RL Calling");
            GetAllDeleteInformationResponse response = new()
            {
                IsSuccess = true,
                Message = "Successful"
            };
            try
            {
                if(_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                using(MySqlCommand sqlCommand = new(SqlQueries.GetAllDeleteInformation, _mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    using(MySqlDataReader dataReader = await sqlCommand.ExecuteReaderAsync())
                    {
                        if(dataReader.HasRows)
                        {
                            response.deletedInformation = new List<DeletedInformation>();

                            while(await dataReader.ReadAsync())
                            {
                                DeletedInformation getData = new();
                                getData.UserId = dataReader["UserId"] != DBNull.Value ? Convert.ToInt32(dataReader["UserId"]) : 0;
                                getData.UserName = dataReader["UserName"] != DBNull.Value ? Convert.ToString(dataReader["UserName"]) : null;
                                getData.EmailId = dataReader["EmailId"] != DBNull.Value ? Convert.ToString(dataReader["EmailId"]) : null;
                                getData.Gender = dataReader["Gender"] != DBNull.Value ? Convert.ToString(dataReader["Gender"]) : null;
                                getData.MobileNumber = dataReader["MobileNumber"] != DBNull.Value ? Convert.ToString(dataReader["MobileNumber"]) : null;
                                getData.Salary = dataReader["Salary"] != DBNull.Value ? Convert.ToInt32(dataReader["Salary"]) : 0;
                                getData.IsActive = dataReader["IsActive"] != DBNull.Value ? Convert.ToBoolean(dataReader["IsActive"]) : false;
                                response.deletedInformation.Add(getData);
                            }
                        } else
                        {
                            response.Message = "No Record at DataBase";
                            _logger.LogWarning("No Record of Deleted user at Database");
                        }
                    }
                }
            }
            catch(Exception e)
            {
                response.IsSuccess = false;
                response.Message = e.Message;
                _logger.LogError("GetAllDeleteInformation RL Error", e.Message);
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }
            return response;
        }

        public async Task<DeleteAllInactiveInformationResponse> DeleteAllInActiveInformation()
        {
            _logger.LogInformation("DeleteAllInActiveInformation RL Calling");
            DeleteAllInactiveInformationResponse response = new()
            {
                IsSuccess = true,
                Message = "Successful"
            };
            try
            {
                if(_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                using (MySqlCommand sqlCommand = new(SqlQueries.DeleteAllInActiveInformation, _mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    int Status = await sqlCommand.ExecuteNonQueryAsync();
                    if(Status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Query Not Executed";
                        _logger.LogError("Error Occur : Query Not Executed");
                        return response;
                    }
                }

            }
            catch(Exception e)
            {
                response.IsSuccess = false;
                response.Message = "Successful";
                _logger.LogError("DeleteAllInActiveInformation Error in RL", e.Message);
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }
            return response;
        }

        public async Task<ReadInformationByIdResponse> ReadInformationByID(ReadInformationByIdRequest request)
        {
            _logger.LogInformation("ReadInformationByID RL Calling");
            ReadInformationByIdResponse response = new()
            {
                IsSuccess = true,
                Message = "Successful"
            };
            try
            {
                if(_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                using(MySqlCommand sqlCommand = new(SqlQueries.ReadInformationByID, _mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@Id", request.Id);
                    using(MySqlDataReader dataReader = await sqlCommand.ExecuteReaderAsync())
                    {
                        if(dataReader.HasRows)
                        {
                            response.readInformation = new GetReadAllInformation();
                            await dataReader.ReadAsync();
                            response.readInformation.UserID = dataReader["UserId"] != DBNull.Value ? Convert.ToInt32(dataReader["UserId"]) : 0;
                            response.readInformation.UserName = dataReader["UserName"] != DBNull.Value ? Convert.ToString(dataReader["UserName"]) : null;
                            response.readInformation.EmailID = dataReader["EmailId"] != DBNull.Value ? Convert.ToString(dataReader["EmailId"]) : null;
                            response.readInformation.Gender = dataReader["Gender"] != DBNull.Value ? Convert.ToString(dataReader["Gender"]) : null;
                            response.readInformation.Salary = dataReader["Salary"] != DBNull.Value ? Convert.ToInt32(dataReader["Salary"]) : 0;
                            response.readInformation.MobileNumber = dataReader["MobileNumber"] != DBNull.Value ? Convert.ToString(dataReader["MobileNumber"]) : null;
                            response.readInformation.IsActive = dataReader["IsActive"] != DBNull.Value ? Convert.ToBoolean(dataReader["IsActive"]) : false;
                        }
                        else
                        {
                            response.Message = "No Data Found for that User";
                            _logger.LogWarning("No Data Found for that User");
                        }
                    }
                }
            }
            catch(Exception e)
            {
                response.IsSuccess = false;
                response.Message = "ReadInformationByID Error from RL " + e.Message;
                _logger.LogError("ReadInformationByID Error from RL", e.Message);
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }
            return response;
        }

        public async Task<UpdateOneInformationByIdResponse> UpdateOneInformationById(UpdateOneInformationByIdRequest request)
        {
            _logger.LogInformation("UpdateOneInformationById RL Calling");
            UpdateOneInformationByIdResponse response = new()
            {
                IsSuccess = true,
                Message = "Successful"
            };
            try
            {
                if(_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                using(MySqlCommand sqlCommand = new MySqlCommand(SqlQueries.UpdateOneInformationById, _mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@UserId", request.UserId);
                    sqlCommand.Parameters.AddWithValue("@Salary", request.Salary);
                    int Status = await sqlCommand.ExecuteNonQueryAsync();

                    if(Status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Unsuccessful Please check userID";
                        _logger.LogError("Unsuccessful Please check userID");
                    }
                }
            }
            catch(Exception e)
            {
                response.IsSuccess = false;
                response.Message = "UpdateOneInformationById Error in RL " + e.Message;
                _logger.LogError($"UpdateOneInformationById in RL ", e.Message);
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }
            return response;
        }
    }
}

