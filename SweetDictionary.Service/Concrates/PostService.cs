using AutoMapper;
using Core.Entities;
using Core.Exceptions;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Posts;
using SweetDictionary.Repository.Repositories.Abstracts;
using SweetDictionary.Service.Abstract;
using SweetDictionary.Service.Constants;
using SweetDictionary.Service.Rules;

namespace SweetDictionary.Service.Concretes;

public sealed class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;
    private readonly PostBusinessRules _businessRules;

    public PostService(IPostRepository postRepository, IMapper mapper, PostBusinessRules businessRules)
    {
        _postRepository = postRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public ReturnModel<PostResponseDto> Add(CreatePostRequestDto dto)
    {
        try
        {
            Post createdPost = _mapper.Map<Post>(dto);
            createdPost.Id = Guid.NewGuid();

            Post post = _postRepository.Add(createdPost);

            PostResponseDto response = _mapper.Map<PostResponseDto>(post);

            return new ReturnModel<PostResponseDto>
            {
                Data = response,
                Message = Messages.PostAddMessage,
                Status = 200,
                Success = true
            };
        }
        catch (Exception)
        {
            return new ReturnModel<PostResponseDto>
            {
                Message = Messages.PostAddFailedMessage,
                Status = 500,
                Success = false
            };
        }
    }

    public ReturnModel<string> Delete(Guid id)
    {
        try
        {
            _businessRules.PostIsPresent(id);

            Post? post = _postRepository.GetById(id);
            Post deletedPost = _postRepository.Delete(post);

            return new ReturnModel<string>
            {
                Data = $"Post Başlığı : {deletedPost.Title}",
                Message = Messages.PostDeleteMessage,
                Status = 204,
                Success = true
            };
        }
        catch (Exception)
        {
            return new ReturnModel<string>
            {
                Message = Messages.PostDeleteFailedMessage,
                Status = 500,
                Success = false
            };
        }
    }

    public ReturnModel<List<PostResponseDto>> GetAll()
    {
        try
        {
            var posts = _postRepository.GetAll();
            List<PostResponseDto> responses = _mapper.Map<List<PostResponseDto>>(posts);

            return new ReturnModel<List<PostResponseDto>>
            {
                Data = responses,
                Message = Messages.PostsListedMessage,
                Status = 200,
                Success = true
            };  
        }
        catch (Exception)
        {
            return new ReturnModel<List<PostResponseDto>>
            {
                Message = Messages.PostsListFailedMessage,
                Status = 500,
                Success = false
            };
        }
    }

    public ReturnModel<List<PostResponseDto>> GetAllByAuthorId(string authorId)
    {
        try
        {
            List<Post> posts = _postRepository.GetAll(p => p.AuthorId == authorId);
            List<PostResponseDto> responses = _mapper.Map<List<PostResponseDto>>(posts);

            return new ReturnModel<List<PostResponseDto>>
            {
                Data = responses,
                Message = $"{Messages.PostsListedByAuthorMessage} Yazar Id: {authorId}",
                Status = 200,
                Success = true
            };
        }
        catch (Exception)
        {
            return new ReturnModel<List<PostResponseDto>>
            {
                Message = Messages.PostsListByAuthorFailedMessage,
                Status = 500,
                Success = false
            };
        }
    }

  
    public ReturnModel<List<PostResponseDto>> GetAllByCategoryId(int id)
    {
        try
        {
            List<Post> posts = _postRepository.GetAll(p => p.CategoryId == id);
            List<PostResponseDto> responses = _mapper.Map<List<PostResponseDto>>(posts);

            return new ReturnModel<List<PostResponseDto>>
            {
                Data = responses,
                Message = $"{Messages.PostsListedByCategoryMessage} Kategori Id: {id}",
                Status = 200,
                Success = true
            };
        }
        catch (Exception)
        {
            return new ReturnModel<List<PostResponseDto>>
            {
                Message = Messages.PostsListByCategoryFailedMessage,
                Status = 500,
                Success = false
            };
        }
    }

    public ReturnModel<List<PostResponseDto>> GetAllByTitleContains(string text)
    {
        try
        {
            var posts = _postRepository.GetAll(x => x.Title.Contains(text));
            var responses = _mapper.Map<List<PostResponseDto>>(posts);

            return new ReturnModel<List<PostResponseDto>>
            {
                Data = responses,
                Message = Messages.PostsListedByTitleMessage,
                Status = 200,
                Success = true
            };
        }
        catch (Exception)
        {
            return new ReturnModel<List<PostResponseDto>>
            {
                Message = Messages.PostsListByTitleFailedMessage,
                Status = 500,
                Success = false
            };
        }
    }

    public ReturnModel<PostResponseDto> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public ReturnModel<PostResponseDto> Update(UpdatePostRequestDto dto)
    {
        throw new NotImplementedException();
    }
}