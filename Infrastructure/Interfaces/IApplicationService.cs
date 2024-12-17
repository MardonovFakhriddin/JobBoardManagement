using Domain.Models;
using Infrastructure.Responses;

namespace Infrastructure.Interfaces;

public interface IApplicationService
{
    Task<ApiResponse<List<Application>>> GetAllAsync (Application application);
    Task<ApiResponse<Application>> GetByIdAsync(int id);
    Task<ApiResponse<bool>> CreateAsync(Application application);
    Task<ApiResponse<bool>> UpdateAsync(Application application);
    Task<ApiResponse<bool>> DeleteAsync(int id);
    Task<ApiResponse<List<Application>>> GetApplicationsByStatusAsync(string status);
    Task<ApiResponse<Application>> GetApplicationCountByUserAsync(int userId);
    Task<ApiResponse<List<Application>>> GetLatestApplicationsByJobAsync(int jobId);
}