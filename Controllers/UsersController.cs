using API.Data;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize] // this will make sure that the user is authenticated before they can access the methods in this controller
[ApiController]
public class UsersController(DataContext context) : BaseApiController // inherit from BaseApiController
{
    [AllowAnonymous] // this will allow the user to access this method without being authenticated
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