using Core.Entities;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Posts;
using SweetDictionary.Service.Concrates;

namespace SweetDictionary.Service.Abstract;

public  interface IPostService
{

    ReturnModel<PostResponseDto> Add(CreatePostRequestDto dto);
    ReturnModel<List<PostResponseDto>> GetAll();

    ReturnModel<PostResponseDto> GetById(Guid id);


    ReturnModel<PostResponseDto> Update(UpdatePostRequestDto dto);
    ReturnModel<string> Delete(Guid id);

    ReturnModel<PostResponseDto> GetAllByCategoryId(int id);
    ReturnModel<PostResponseDto> GetAllByAuthorId(long authorId);
    ReturnModel<PostResponseDto> GetAllByTitleContains(string text);
}
