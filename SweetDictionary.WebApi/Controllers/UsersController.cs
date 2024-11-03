﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SweetDictionary.Models.Users;
using SweetDictionary.Service.Abstract;

namespace SweetDictionary.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserService _userService) : ControllerBase
{



    [HttpPost("create")]
    public async Task<IActionResult> CreateUser([FromBody] RegisterRequestDto dto)
    {
        var result = await _userService.CreateUserAsync(dto);
        return Ok(result);
    }


    [HttpGet("getbyemail")]

    public async Task<IActionResult> GetByEmail([FromQuery] string email)
    {
        var resulr=await _userService.GetByEmailAsync(email);
        return Ok(resulr); 
    }
}