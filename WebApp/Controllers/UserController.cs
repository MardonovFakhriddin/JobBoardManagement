using Domain.Models;
using Infrastructure.Interfaces;
using Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<ApiResponse<List<User>>> GetAllAsync(User application)
    {
        var response = await userService.GetAllAsync(application);
        return response;
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<User>> GetByIdAsync(int id)
    {
        var response = await userService.GetByIdAsync(id);
        return response;
    }
    [HttpPost]
    public async Task<ApiResponse<bool>> CreateAsync(User application)
    {
        var response = await userService.CreateAsync(application);
        return response;
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateAsync(User application)
    {
        var response = await userService.UpdateAsync(application);
        return response;
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteAsync(int id)
    {
        var response = await userService.DeleteAsync(id);
        return response;
    }
}