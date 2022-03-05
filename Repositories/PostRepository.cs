using System.Collections.Generic;
using System.Linq;
using BlogExample.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BlogExample.Repositories
{
    public class PostRepository : Repository<Post>
    {
        private readonly SqlConnection _connection;

        public PostRepository(SqlConnection connection)
            : base(connection)
            => _connection = connection;

        public List<Post> GetFull(Post post)
        {
            var query = @"
            SELECT
                [Post].*,
                [Category].Id AS 'IdCategory', [Category].*,
                [User].Id AS 'IdUser', [User].*,
                [Tag].Id AS 'IdTag', [Tag].*
            FROM
                [Post]
            INNER JOIN
                [Category] ON [Post].[CategoryId] = [Category].[Id]
            INNER JOIN
                [User] ON [Post].[AuthorId] = [User].[Id]
            LEFT JOIN 
                    [PostTag] ON [PostTag].[PostId] = [Post].[Id]
            LEFT JOIN 
                    [Tag] ON [PostTag].[TagId] = [Tag].[Id]
            WHERE
                [Post].[Id] = @Id OR @Id = 0";

            var posts = new List<Post>();

            // var items = _connection.Query<Post, Category, User, Tag, Post>(
            //     query,
            //     (queryPost, category, user, tag) =>
            //     {
            //         queryPost.Category = category;
            //         queryPost.Author = user;

            //         var consultPost = posts.FirstOrDefault(x => x.Id == queryPost.Id);
            //         if (consultPost == null)
            //         {
            //             consultPost = queryPost;
            //             if (tag != null)
            //                 consultPost.Tags.Add(tag);

            //             posts.Add(consultPost);
            //         }
            //         else
            //             consultPost.Tags.Add(tag);
            //         return queryPost;
            //     }, new
            //     {
            //         post.Id
            //     }, splitOn: "IdCategory, IdUser, IdTag");
            return posts;
        }
    }
}