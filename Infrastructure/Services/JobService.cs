using System.Net;
using Dapper;
using Domain.Models;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;
using Infrastructure.Responses;

namespace Infrastructure.Services;

public class JobService(IContext context) : IJobService
{
    public async Task<ApiResponse<List<Job>>> GetAllAsync(Job job)
    {
        try
        {
            using var connection = context.Connection();
            var cmd = "SELECT * FROM Jobs";
            var response = await context.Connection().QueryAsync<Job>(cmd);
            return new ApiResponse<List<Job>>(response.ToList());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<ApiResponse<Job>> GetByIdAsync(int id)
    {
        try
        {
            using var connection = context.Connection();
            var cmd = "SELECT * FROM Jobs WHERE userId =@id";
            var response = await context.Connection().QuerySingleOrDefaultAsync<Job>(cmd, new { JobId = id });
            if (response == null) return new ApiResponse<Job>(HttpStatusCode.NotFound, "Job not found");
            return new ApiResponse<Job>(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<ApiResponse<bool>> CreateAsync(Job job)
    {
        try
        {
            using var connection = context.Connection();
            var cmd =
                "INSERT INTO Jobs (EmployerId,Title,Description,Salary,Country,City,Status,CreatedAt,UpdatedAt) values (@EmployerId,@Title,@Description,@Salary,@Country,@City,@Status,@CreatedAt,@UpdatedAt)";
            var response = await context.Connection().ExecuteAsync(cmd, job);
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

    public async Task<ApiResponse<bool>> UpdateAsync(Job job)
    {
        try
        {
            using var connection = context.Connection();
            var cmd =
                "INSERT INTO users (EmployerId=@EmployerId,Title=@Title,Description=@Description,Salary=@Salary,Country=@Country,City=@City,Status=@Status,CreatedAt=@CreatedAt,UpdatedAt=@UpdatedAt)";
            var response = await context.Connection().ExecuteAsync(cmd, job);
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
            var cmd = "DELETE FROM Jobs WHERE JobId = @id";
            var response = await context.Connection().ExecuteAsync(cmd, new { JobId = id });
            if (response == 0) return new ApiResponse<bool>(HttpStatusCode.NotFound, "Job not found");
            return new ApiResponse<bool>(response != 0);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<ApiResponse<Job>> GetSalaryAvgAsync(Job job)
    {
        try
        {
            using var connection = context.Connection();
            var cmd = "SELECT AVG(Salary) AS AverageSalary FROM Jobs;";
            var response = await connection.QuerySingleAsync<Job>(cmd, job);
            return new ApiResponse<Job>(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<ApiResponse<List<Job>>> GetRecentJobsAsync()
    {
        try
        {
            using var connection = context.Connection();
            var cmd = "SELECT * FROM Jobs ORDER BY CreatedAt DESC LIMIT 10;";
            var response = await connection.QueryAsync<Job>(cmd);
            return new ApiResponse<List<Job>>(response.ToList());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<ApiResponse<Job>> GetJobWithHighestSalaryAsync()
    {
        try
        {
            using var connection = context.Connection();
            var cmd = "SELECT * FROM Jobs ORDER BY Salary DESC LIMIT 1;";
            var response = await connection.QuerySingleAsync<Job>(cmd);
            return new ApiResponse<Job>(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<ApiResponse<Job>> GetJobWithLowestSalaryAsync()
    {
        try
        {
            using var connection = context.Connection();
            var cmd = "SELECT * FROM Jobs ORDER BY Salary ASC LIMIT 1;";
            var response = await connection.QuerySingleAsync<Job>(cmd);
            return new ApiResponse<Job>(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<ApiResponse<Job>> GetJobCountByCityAsync(string city)
    {
        try
        {
            using var connection = context.Connection();
            var cmd = "SELECT COUNT(*) AS JobCount FROM Jobs WHERE City = @City;";
            var response = await connection.QuerySingleAsync<Job>(cmd, new { City = city });
            return new ApiResponse<Job>(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}