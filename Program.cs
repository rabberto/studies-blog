using System;
using BlogExample.Models;
using BlogExample.Repositories;
using BlogExample.Services;
using Microsoft.Data.SqlClient;

namespace BlogExample
{
    class Program
    {
        private const string CONNECTION_STRING = "Server=.\\SQLEXPRESS;TrustServerCertificate=True;Database=dbBlog;User ID=sa;Password=8&r1@NH@";

        static void Main(string[] args)
        {
            var connection = new SqlConnection(CONNECTION_STRING);
            var userService = new UserService(connection);
            var tagService = new TagService(connection);
            var roleService = new RoleService(connection);
            var postService = new PostService(connection);


            connection.Open();
            // var items = userService.GetUserWithRoles();
            var posts = postService.GetPostFull(new Post { });
            // var item = postService.GetPost(1);
            // GetUser(1, connection);
            // CreateUser(connection);
            // UpdateUser(connection);
            // DeleteUser(connection);
            // var roles = roleService.GetRoles();
            // var tags = tagService.GetTags();
            connection.Close();

            foreach (var post in posts)
            {
                Console.WriteLine($"Title: {post.Title}");
                Console.WriteLine($" Category: {post.Category.Name}");
                Console.WriteLine($" Author: {post.Author.Name}");
                foreach (var tag in post.Tags)
                    Console.WriteLine($"  - Tag: {tag.Name}");
            }

            // foreach (var role in roles)
            //     Console.WriteLine($"Role: {role.Name}");

            // foreach (var tag in tags)
            //     Console.WriteLine($"Usuário: {tag.Name}");
        }
    }
}

// var user = new User
//             {
//                 Name = "Graziela Tullio",
//                 Email = "graziela.tullio@yahoo.com.br",
//                 PasswordHash = "1234",
//                 Bio = "Especialista Financeira",
//                 Image = "image-url",
//                 Slug = "graziela-tullio"
//             };


//             update
//             var user = new User
//             {
//                 Id = 2,
//                 Name = "Graziela Tullio Berto",
//                 Email = "graziela.tullio@yahoo.com.br",
//                 PasswordHash = "1234",
//                 Bio = "Especialista Financeira",
//                 Image = "image-url",
//                 Slug = "graziela-tullio"
//             };