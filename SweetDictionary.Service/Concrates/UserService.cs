using Core.Exceptions;
using Microsoft.AspNetCore.Identity;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Users;
using SweetDictionary.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Service.Concrates;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;

    public UserService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<User> CreateUserAsync(RegisterRequestDto registerRequestDto)
    {
        User user = new User()
        {
            Email = registerRequestDto.Email,
            UserName = registerRequestDto.UserName,
            BirthDate = registerRequestDto.BirthDate,
        };
        var result=await _userManager.CreateAsync(user,registerRequestDto.Password);
        //CreateAsync:veri tabanindan bir kulanici olusturur

        return user;

    }

    public async Task<User> GetByEmailAsync(string email)
    {
       var user= await _userManager.FindByEmailAsync(email);
        UserIsPresent(user);
         
        return user;
    }





























    private  void UserIsPresent(User? user)
    {
        if (user == null)
        {
            throw new NotFoundException("kullanici Bulunumadi. ");
        }
    }
}
