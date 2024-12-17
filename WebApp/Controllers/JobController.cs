using System.Net;
using Domain.Models;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;
using Infrastructure.Responses;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobController(IJobService jobService) : ControllerBase
{
    [HttpGet]
    public async Task<ApiResponse<List<Job>>> GetAllAsync(Job job)
    {
        var response = await jobService.GetAllAsync(job);
        return response;
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Job>> GetByIdAsync(int id)
    {
        var response = await jobService.GetByIdAsync(id);
        return response;
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> CreateAsync(Job job)
    {
        var response = await jobService.CreateAsync(job);
        return response;
    }
    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateAsync(Job job)
    {
        var response = await jobService.UpdateAsync(job);
        return response;
    }
    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteAsync(int id)
    {
        var response = await jobService.DeleteAsync(id);
        return response;
    }
    [HttpGet("/api/jobs/average-salary")]
    public async Task<ApiResponse<Job>> GetSalaryAvgAsync(Job job)
    {
        var response = await jobService.GetSalaryAvgAsync(job);
        return response;
    }

    [HttpGet("/api/jobs/recent ")]
    public async Task<ApiResponse<List<Job>>> GetRecentJobsAsync()
    {
        var response = await jobService.GetRecentJobsAsync();
        return response;
    }

    [HttpGet("/api/jobs/highest-salary")]
    public async Task<ApiResponse<Job>> GetJobWithHighestSalaryAsync()
    {
        var response = await jobService.GetJobWithHighestSalaryAsync();
        return response;
    }
    [HttpGet("/api/jobs/lowest-salary")]
    public async Task<ApiResponse<Job>> GetJobWithLowestSalaryAsync()
    {
        var response = await jobService.GetJobWithLowestSalaryAsync();
        return response;
    }
    [HttpGet("/api/jobs/count/location/{city}")]
    public async Task<ApiResponse<Job>> GetJobCountByCityAsync(string city)
    {
        var response = await jobService.GetJobCountByCityAsync(city);
        return response;
    }
}