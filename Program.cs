using System;
using BlogExample.Models;
using BlogExample.Repositories;
using BlogExample.Screens;
using BlogExample.Services;
using Microsoft.Data.SqlClient;

namespace BlogExample
{
    class Program
    {
        private const string CONNECTION_STRING = "Server=.\\SQLEXPRESS;TrustServerCertificate=True;Database=dbBlog;User ID=sa;Password=8&r1@NH@";

        static void Main(string[] args)
        {
            Database.Connection = new SqlConnection(CONNECTION_STRING);
            Database.Connection.Open();
            // Debug();
            MenuScreen.Load();
            Database.Connection.Close();
        }

        public static void Debug()
        {
            var postService = new PostService(Database.Connection);
            var categoryService = new CategoryService(Database.Connection);
            var userService = new UserService(Database.Connection);
            postService.CreatePost(new Post
            {
                Title = "title",
                Body = "body",
                Summary = "summary",
                Slug = "slug2",
                CategoryId = 1,
                // Category = categoryService.GetCategory(1),
                AuthorId = 1,
                // Author = userService.GetUser(1)
            });
        }
    }
}