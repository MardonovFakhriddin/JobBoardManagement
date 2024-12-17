using Infrastructure.Responses;

namespace Infrastructure.Interfaces;
using Domain.Models;

public interface IJobService
{
    Task<ApiResponse<List<Job>>> GetAllAsync(Job job);
    Task<ApiResponse<Job>> GetByIdAsync(int id);
    Task<ApiResponse<bool>> CreateAsync(Job job);
    Task<ApiResponse<bool>> UpdateAsync(Job job);
    Task<ApiResponse<bool>> DeleteAsync(int id);
    Task<ApiResponse<Job>> GetSalaryAvgAsync(Job job);
    Task<ApiResponse<List<Job>>> GetRecentJobsAsync();
    Task<ApiResponse<Job>> GetJobWithHighestSalaryAsync();
    Task<ApiResponse<Job>> GetJobWithLowestSalaryAsync();
    Task<ApiResponse<Job>> GetJobCountByCityAsync(string city);
}