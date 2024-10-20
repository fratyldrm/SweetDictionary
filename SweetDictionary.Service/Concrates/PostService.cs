
using AutoMapper;
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
    
    public ReturnModels<PostResponseDto> Add(CreatePostRequestDto dto)
    {
         Post  createdPost= _mapper.Map<Post>(dto); 
        createdPost.Id=Guid.NewGuid();

        Post post=_postRepository.Add(createdPost);
        PostResponseDto response = _mapper.Map<PostResponseDto>(post);
        return new ReturnModels<PostResponseDto>
        {
            Data= response,
            Success= true,
            Message="Post Eklendi",
            Status=200,
        };
    }

    public ReturnModels<List<PostResponseDto>> GetAll()
    {
         var posts= _postRepository.GetAll();
        List<PostResponseDto> response=_mapper.Map<List<PostResponseDto>>(posts);
        return new ReturnModels<List<PostResponseDto>>
        {
            Data = response,
            Success = true,
            Message = string.Empty,
            Status = 200,
        };
    }

    public ReturnModels<PostResponseDto> GetById(Guid id)
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
}
