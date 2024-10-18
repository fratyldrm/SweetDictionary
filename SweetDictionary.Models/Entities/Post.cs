

using Core.Entities;

namespace SweetDictionary.Models.Entities;

public sealed class Post: Entity<Guid>
{
   
    public string Title { get; set; }
    public string Context { get; set; }
}



