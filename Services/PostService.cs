using System.Collections.Generic;
using BlogExample.Models;
using BlogExample.Repositories;
using Microsoft.Data.SqlClient;

namespace BlogExample.Services
{
    public class PostService
    {

        private readonly PostRepository _repository;

        public PostService(SqlConnection connection)
            => _repository = new PostRepository(connection);

        public IEnumerable<Post> GetPosts()
            => _repository.GetAll();

        public Post GetPost(int id)
            => _repository.Get(id);

        public void CreatePost(Post post)
            => _repository.Create(post);

        public void UpdatePost(Post post)
            => _repository.Update(post);

        public void DeletePost(Post post)
            => _repository.Delete(post);

        public void DeletePost(int id)
            => _repository.Delete(id);

        public List<Post> GetPostFull(Post post)
            => _repository.GetFull(post);
    }
}