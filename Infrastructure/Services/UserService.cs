using System.Net;
using Dapper;
using Domain.Models;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;
using Infrastructure.Responses;

namespace Infrastructure.Services;

public class  UserService(IContext context) : IUserService
{


    public async Task<ApiResponse<List<User>>> GetAllAsync(User user)
    {
        try
        {
            using var connection = context.Connection();
            var cmd = "SELECT * FROM users";
            var response = await context.Connection().QueryAsync<User>(cmd);
            return new ApiResponse<List<User>>(response.ToList());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<ApiResponse<User>> GetByIdAsync(int id)
    {
        try
        {
            using var connection = context.Connection();
            var cmd = "SELECT * FROM users WHERE userId =@id";
            var response = await context.Connection().QuerySingleOrDefaultAsync<User>(cmd, new { UserId = id });
            if (response == null) return new ApiResponse<User>(HttpStatusCode.NotFound, "User not found");
            return new ApiResponse<User>(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<ApiResponse<bool>> CreateAsync(User user)
    {
        try
        {
            using var connection = context.Connection();
            var cmd =
                "INSERT INTO users (FullName,Email,Phone,Role,CreatedAt) values (@FullName, @Email, @Phone, @Role, @CreatedAt)";
            var response = await context.Connection().ExecuteAsync(cmd, user);
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

    public async Task<ApiResponse<bool>> UpdateAsync(User user)
    {
        try
        {
            using var connection = context.Connection();
            var cmd =
                "INSERT INTO users (FullName=@FullName,Email=@Email,Phone=@Phone,Role=@Role,CreatedAt=@CreatedAt)";
            var response = await context.Connection().ExecuteAsync(cmd, user);
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
            var cmd = "DELETE FROM users WHERE UserId = @id";
            var response = await context.Connection().ExecuteAsync(cmd, new { UserId = id });
            if (response == 0) return new ApiResponse<bool>(HttpStatusCode.NotFound, "User not found");
            return new ApiResponse<bool>(response != 0);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}