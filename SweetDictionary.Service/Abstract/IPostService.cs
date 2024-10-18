using Core.Entities;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Service.Abstract;

public  interface IPostService
{

    ReturnModels<PostResponseDto> Add(CreatePostRequestDto dto);
    ReturnModels<List<PostResponseDto>> GetAll();

    ReturnModels<PostResponseDto> GetById(Guid id);
}
