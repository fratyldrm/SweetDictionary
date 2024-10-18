
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
        throw new NotImplementedException();
    }

    public ReturnModels<PostResponseDto> GetById(Guid id)
    {
        throw new NotImplementedException();
    }
}
