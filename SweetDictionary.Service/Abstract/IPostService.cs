using Core.Entities;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Posts;

namespace SweetDictionary.Service.Abstract;

public  interface IPostService
{

    ReturnModels<PostResponseDto> Add(CreatePostRequestDto dto);
    ReturnModels<List<PostResponseDto>> GetAll();

    ReturnModels<PostResponseDto> GetById(Guid id);
}
