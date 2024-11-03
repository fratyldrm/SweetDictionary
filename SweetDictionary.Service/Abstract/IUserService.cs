using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Users;


namespace SweetDictionary.Service.Abstract;

public  interface IUserService
{

    Task<User> CreateUserAsync(RegisterRequestDto registerRequestDto); 

    Task<User> GetByEmailAsync(string email);
}
