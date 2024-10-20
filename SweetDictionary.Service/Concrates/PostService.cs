
using AutoMapper;
using Azure;
using Core.Entities;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Posts;
using SweetDictionary.Repository.Repositories.Abstracts;
using SweetDictionary.Service.Abstract;


namespace SweetDictionary.Service.Concrates;

public sealed class PostService :IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public PostService(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }
    
    public ReturnModel<PostResponseDto> Add(CreatePostRequestDto dto)
    {
         Post  createdPost= _mapper.Map<Post>(dto); 
        createdPost.Id=Guid.NewGuid();

        Post post=_postRepository.Add(createdPost);
        PostResponseDto response = _mapper.Map<PostResponseDto>(post);
        return new ReturnModel<PostResponseDto>
        {
            Data= response,
            Success= true,
            Message="Post Eklendi",
            Status=200,
        };
    }

    public ReturnModel<string> Delete(Guid id)
    {
        Post? post = _postRepository.GetById(id);
        Post deletedPost = _postRepository.Delete(post);

        return new ReturnModel<string>
        {
            Data = $"Post Başlığı : {deletedPost.Title}",
            Message = "Post Silindi",
            Status = 204,
            Success = true
        };
        
            
        
    }

    public ReturnModel<List<PostResponseDto>> GetAll()
    {
         var posts= _postRepository.GetAll();
        List<PostResponseDto> response=_mapper.Map<List<PostResponseDto>>(posts);
        return new ReturnModel<List<PostResponseDto>>
        {
            Data = response,
            Success = true,
            Message = string.Empty,
            Status = 200,
        };
    }

    public ReturnModel<List<PostResponseDto>> GetAllByAuthorId(long authorId)
    {
        List<Post> posts = _postRepository.GetAllByAuthorId(authorId);
        List<PostResponseDto> responses = _mapper.Map<List<PostResponseDto>>(posts);

        return new ReturnModel<List<PostResponseDto>>
        {
            Data = responses,
            Message = $"Yazar Id sine göre Postlar listelendi : Yazar Id: {authorId}",
            Status = 200,
            Success = true
        };

    }

    public ReturnModel<List<PostResponseDto>> GetAllByCategoryId(int id)
    {
        List<Post> posts = _postRepository.GetAllByCategoryId(id);
        List<PostResponseDto> responses = _mapper.Map<List<PostResponseDto>>(posts);
        return new ReturnModel<List<PostResponseDto>>
        {
            Data = responses,
            Message = $"Kategori Id sine göre Postlar listelendi : Kategori Id: {id}",
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<List<PostResponseDto>> GetAllByTitleContains(string text)
    {
        var posts = _postRepository.GetAllByTitleContains(text);
        var responses = _mapper.Map<List<PostResponseDto>>(posts);
        return new ReturnModel<List<PostResponseDto>>
        {
            Data = responses,
            Message = string.Empty,
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<PostResponseDto> GetById(Guid id)  
    {
        var post= _postRepository.GetById(id);
        var response= _mapper.Map<PostResponseDto>(post);
        return new retunModels<PostResponseDto>
        {
            Data = response,
            Success= true,
            Message= "İlgili post gösterild",
            Status=200,

        };
        
    }

    public ReturnModel<PostResponseDto> Update(UpdatePostRequestDto dto)
    {
        throw new NotImplementedException();
    }

    ReturnModel<PostResponseDto> IPostService.GetAllByAuthorId(long authorId)
    {
        throw new NotImplementedException();
    }
}
