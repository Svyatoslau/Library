﻿using Library.Core.Models.Dto;
using Library.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;
[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService) =>
        _userService = userService;

    [HttpPost("login")]
    public async Task<ActionResult> LoginUserAsync(
        [FromBody] LoginUserDto model    
    )
    {
        var token = await _userService
            .Authenticate(model);

        if (token is null)
        {
            return BadRequest(new { message = "Not valid credentials" });
        }

        return Ok(new {token = token});
    }

    [HttpPost("registration")]
    public async Task<ActionResult> RegistrUserAsync(
        [FromBody] LoginUserDto model
    ) 
    {
        var user = await _userService
            .Registr(model);

        if (user is null)
        {
            return BadRequest(new { message = $"User {model.Nickname} exists" });
        }

        return Ok(new { message = "Registration completed!" });
    }
}
