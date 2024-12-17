using System.Net;
using Dapper;
using Domain.Models;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;
using Infrastructure.Responses;

namespace Infrastructure.Services;

public class ApplicationService(IContext context) : IApplicationService
{
    public async Task<ApiResponse<List<Application>>> GetAllAsync(Application application)
    {
        try
        {
            using var connection = context.Connection();
            var cmd = "SELECT * FROM Applications";
            var response = await context.Connection().QueryAsync<Application>(cmd);
            return new ApiResponse<List<Application>>(response.ToList());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<ApiResponse<Application>> GetByIdAsync(int id)
    {
        try
        {
            using var connection = context.Connection();
            var cmd = "SELECT * FROM Applications WHERE userId =@id";
            var response = await context.Connection()
                .QuerySingleOrDefaultAsync<Application>(cmd, new { ApplicationId = id });
            if (response == null) return new ApiResponse<Application>(HttpStatusCode.NotFound, "Application not found");
            return new ApiResponse<Application>(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<ApiResponse<bool>> CreateAsync(Application application)
    {
        try
        {
            using var connection = context.Connection();
            var cmd =
                "INSERT INTO Applications (EmployerId,Title,Description,Salary,Country,City,Status,CreatedAt,UpdatedAt) values (@EmployerId,@Title,@Description,@Salary,@Country,@City,@Status,@CreatedAt,@UpdatedAt)";
            var response = await context.Connection().ExecuteAsync(cmd, application);
            if (response == 0)
                return new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error");
            return new ApiResponse<bool>(response > 0);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<ApiResponse<bool>> UpdateAsync(Application application)
    {
        try
        {
            using var connection = context.Connection();
            var cmd =
                "INSERT INTO users (EmployerId=@EmployerId,Title=@Title,Description=@Description,Salary=@Salary,Country=@Country,City=@City,Status=@Status,CreatedAt=@CreatedAt,UpdatedAt=@UpdatedAt)";
            var response = await context.Connection().ExecuteAsync(cmd, application);
            if (response == 0)
                return new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error");
            return new ApiResponse<bool>(response > 0);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<ApiResponse<bool>> DeleteAsync(int id)
    {
        try
        {
            using var connection = context.Connection();
            var cmd = "DELETE FROM Applications WHERE ApplicationId = @id";
            var response = await context.Connection().ExecuteAsync(cmd, new { ApplicationId = id });
            if (response == 0) return new ApiResponse<bool>(HttpStatusCode.NotFound, "Application not found");
            return new ApiResponse<bool>(response != 0);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<ApiResponse<List<Application>>> GetApplicationsByStatusAsync(string status)
    {
        try
        {
            using var connection = context.Connection();
            string cmd = "SELECT * FROM Applications WHERE Status = @Status";
            var response = await connection.QueryAsync<Application>(cmd, new { Status = status });
            return new ApiResponse<List<Application>>(response.ToList());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<ApiResponse<Application>> GetApplicationCountByUserAsync(int userId)
    {
        try
        {
            using var connection = context.Connection();
            var cmd = "SELECT COUNT(*) AS ApplicationCount FROM Applications WHERE ApplicantId = @UserId";
            var response = await connection.QuerySingleAsync<Application>(cmd, new { UserId = userId });
            return new ApiResponse<Application>(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    public async Task<ApiResponse<List<Application>>> GetLatestApplicationsByJobAsync(int jobId)
    {
        try
        {
            using var connection = context.Connection();
            var cmd = @"SELECT * FROM Applications WHERE JobId = @JobId ORDER BY CreatedAt DESC LIMIT 5;";;
            var response = await connection.QueryAsync<Application>(cmd, new { JobId = jobId });
            return new ApiResponse<List<Application>>(response.ToList());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}

