using Domain.Models;
using Infrastructure.Responses;

namespace Infrastructure.Interfaces;

public interface IUserService
{
    Task<ApiResponse<List<User>>> GetAllAsync (User user);
    Task<ApiResponse<User>> GetByIdAsync(int id);
    Task<ApiResponse<bool>> CreateAsync(User user);
    Task<ApiResponse<bool>> UpdateAsync(User user);
    Task<ApiResponse<bool>> DeleteAsync(int id);
}