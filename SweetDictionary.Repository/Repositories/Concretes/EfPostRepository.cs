using Core.Repository;
using SweetDictionary.Models.Entities;
using SweetDictionary.Repository.Contexts;
using SweetDictionary.Repository.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Repository.Repositories.Concretes;

public class EfPostRepository : EfRepositoryBase<BaseDbContext, Post, Guid>, IPostRepository
{
    public EfPostRepository(BaseDbContext context) : base(context)
    {

    } 
}
 