using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] // route is now api/users.....[controller] is a token that will be replaced by the name of the controller class minus the word "Controller"
public class UsersController(DataContext context) : ControllerBase
{

    [HttpGet(Name = "GetUsers")]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        return await context.Users.ToListAsync();
    }

    [HttpGet("{id}", Name = "GetUser")] // api/users/3
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        var user = await context.Users.FindAsync(id);
        if (user == null) return NotFound();
        return user;
    }
}