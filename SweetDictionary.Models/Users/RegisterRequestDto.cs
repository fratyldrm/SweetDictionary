using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Models.Users;

public sealed record RegisterRequestDto(string Name,
    string LastName,
    string UserName,
    string Email,
    string Password,
   DateTime BirthDate
    );

