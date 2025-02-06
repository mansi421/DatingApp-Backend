using System;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController] // attribute that tells the controller that it is an API controller
[Route("api/[controller]")] // route is now api/users.....[controller] is a token that will be replaced by the name of the controller class minus the word "Controller"
public class BaseApiController : ControllerBase
{

}
