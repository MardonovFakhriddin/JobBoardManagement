using Domain.Models;
using Infrastructure.Interfaces;
using Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApplicationController(IApplicationService applicationService) : ControllerBase
{
    [HttpGet]
    public async Task<ApiResponse<List<Application>>> GetAllAsync(Application application)
    {
        var response = await applicationService.GetAllAsync(application);
        return response;
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Application>> GetByIdAsync(int id)
    {
        var response = await applicationService.GetByIdAsync(id);
        return response;
    }
    [HttpPost]
    public async Task<ApiResponse<bool>> CreateAsync(Application application)
    {
        var response = await applicationService.CreateAsync(application);
        return response;
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateAsync(Application application)
    {
        var response = await applicationService.UpdateAsync(application);
        return response;
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteAsync(int id)
    {
        var response = await applicationService.DeleteAsync(id);
        return response;
    }

    [HttpGet("/api/applications/status/{status}")]
    public async Task<ApiResponse<List<Application>>> GetApplicationsByStatusAsync(string status)
    {
        var response = await applicationService.GetApplicationsByStatusAsync(status);
        return response;
    }

    [HttpGet("/api/applications/user/{userId}/count")]
    public async Task<ApiResponse<Application>> GetApplicationCountByUserAsync(int userId)
    {
        var response = await applicationService.GetApplicationCountByUserAsync(userId);
        return response;
    }


    [HttpGet("/api/applications/job/{jobId}/latest")]
    public async Task<ApiResponse<List<Application>>> GetLatestApplicationsByJobAsync(int jobId)
    {
        var response = await applicationService.GetLatestApplicationsByJobAsync(jobId);
        return response;
    }
}