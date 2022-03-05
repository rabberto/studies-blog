using System;
using BlogExample.Models;
using BlogExample.Services;

namespace BlogExample.Screens
{
    public class PostScreen
    {
        private PostService _service;
        private CategoryService _serviceCategory;
        private UserService _serviceUser;

        public PostScreen()
        {
            _service = new PostService(Database.Connection);
            _serviceCategory = new CategoryService(Database.Connection);
            _serviceUser = new UserService(Database.Connection);
        }

        public void Load()
        {
            Console.Clear();
            Console.WriteLine("GESTÃO DE POST");
            Console.WriteLine("--------------------");
            Console.WriteLine("");
            Console.WriteLine("1 - Listar Posts");
            Console.WriteLine("2 - Cadastrar Post");
            Console.WriteLine("3 - Atualizar Post");
            Console.WriteLine("4 - Excluir Post");
            Console.WriteLine("9 - Menu Principal");
            Console.WriteLine("");
            Console.Write("Selecione a opção: ");
            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    List();
                    break;
                case 2:
                    Create();
                    break;
                case 3:
                    Update();
                    break;
                case 4:
                    Delete();
                    break;
                case 9:
                    MenuScreen.Load();
                    break;
            }
        }

        private void List()
        {
            Console.Clear();

            // foreach (var post in _service.GetPostFull(new Post { }))
            //     Console.WriteLine($"{post.Id}. {post.Title} - {post.Category.Name} ({post.Slug}) | {post.Author.Name} criado em {post.CreateDate} alterado em {post.LastUpdateDate} ");

            Console.ReadKey();
            Load();
        }

        private void Create()
        {
            Console.Clear();
            Console.Write("Titulo: ");
            var title = Console.ReadLine();
            Console.Write("Conteúdo: ");
            var body = Console.ReadLine();
            Console.Write("Sumário: ");
            var summary = Console.ReadLine();
            Console.Write("Slug: ");
            var slug = Console.ReadLine();
            Console.Write($"{GetUsers()} : ");
            var authorId = int.Parse(Console.ReadLine());
            Console.Write($"{GetCategories()} : ");
            var categoryId = int.Parse(Console.ReadLine());

            _service.CreatePost(new Post
            {
                Title = title,
                Body = body,
                Summary = summary,
                Slug = slug,
                // CategoryId = categoryId
                // AuthorId = authorId
            });
            Console.WriteLine("Post criado com sucesso");
            Console.ReadKey();
            List();
        }

        private void Update()
        {
            Console.Write("Id: ");
            var id = int.Parse(Console.ReadLine());
            Console.Write("Titulo: ");
            var title = Console.ReadLine();
            Console.Write("Conteúdo: ");
            var body = Console.ReadLine();
            Console.Write("Sumário: ");
            var summary = Console.ReadLine();
            Console.Write("Slug: ");
            var slug = Console.ReadLine();
            Console.Write($"{GetCategories()} : ");
            var categoryId = int.Parse(Console.ReadLine());
            Console.Write($"{GetUsers()} : ");
            var authorId = int.Parse(Console.ReadLine());

            _service.CreatePost(new Post
            {
                Id = id,
                Title = title,
                Body = body,
                Summary = summary,
                Slug = slug,
                // CategoryId = categoryId
                // AuthorId = authorId
            });
            Console.WriteLine("Post atualizado com sucesso");
            Console.ReadKey();
            List();
        }

        private void Delete()
        {
            Console.Write("Id: ");

            _service.DeletePost(int.Parse(Console.ReadLine()));

            Console.WriteLine("Post excluido com sucesso");
            Console.ReadKey();
            List();
        }

        private string GetCategories()
        {
            string categories = "Informe o Id da Categoria (";
            foreach (var category in _serviceCategory.GetCategories())
                categories += $"{category.Id} => {category.Name} ";
            categories += ")";
            return categories;
        }

        private string GetUsers()
        {
            string users = "Informe o Id do Autor (";
            foreach (var user in _serviceUser.GetUsers())
                users += $" {user.Id} => {user.Name} ";
            users += ")";
            return users;
        }
    }
}