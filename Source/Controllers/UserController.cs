using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using ServerSide.Source.Data.Services;
using ServerSide.Source.Models;

namespace ServerSide.Source.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserService service;

    public UsersController(UserService service)
    {
        this.service = service;
    }

    [HttpGet]
    public async Task<List<UserModel>> Get() =>
        await service.GetAllAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<UserModel>> Get(ulong id)
    { 
        var user = await service.GetByIdAsync(id);

        if(user == null) 
            return NotFound();

    return Ok(user);
    }   
}