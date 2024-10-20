using Core.Entities;
using SweetDictionary.Models.Posts;

namespace SweetDictionary.Service.Concrates
{
    internal class retunModels<T> : ReturnModel<PostResponseDto>
    {
        public PostResponseDto Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
    }
}