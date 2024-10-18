using Microsoft.EntityFrameworkCore;
using SweetDictionary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Repository.Contexts;

public  class BaseDbContext:DbContext
{
    public BaseDbContext(DbContextOptions opt):base(opt)
    {
        
    }


    public DbSet<Post> Posts { get; set; }

}
