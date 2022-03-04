using System;
using BlogExample.Models;
using BlogExample.Services;

namespace BlogExample.Screens
{
    public class CategoryScreen
    {
        private CategoryService _service;

        public CategoryScreen()
            => _service = new CategoryService(Database.Connection);

        public void Load()
        {
            Console.Clear();
            Console.WriteLine("GESTÃO DE CATEGORIAS");
            Console.WriteLine("--------------------");
            Console.WriteLine("");
            Console.WriteLine("1 - Listar Categorias");
            Console.WriteLine("2 - Cadastrar Categorias");
            Console.WriteLine("3 - Atualizar Categorias");
            Console.WriteLine("4 - Excluir Categorias");
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

            foreach (var category in _service.GetCategories())
                Console.WriteLine($"{category.Id} - {category.Name} ({category.Slug})");

            Console.ReadKey();
            Load();
        }

        private void Create()
        {
            Console.Clear();
            Console.Write("Nome: ");
            var name = Console.ReadLine();
            Console.Write("Slug: ");
            var slug = Console.ReadLine();
            _service.CreateCategory(new Category
            {
                Name = name,
                Slug = slug
            });
            Console.WriteLine("Categoria cadastrada com sucesso");
            Console.ReadKey();
            List();
        }

        private void Update()
        {
            Console.Clear();
            Console.Write("Id: ");
            var id = int.Parse(Console.ReadLine());
            Console.Write("Nome: ");
            var name = Console.ReadLine();
            Console.Write("Slug: ");
            var slug = Console.ReadLine();
            _service.UpdateCategory(new Category
            {
                Id = id,
                Name = name,
                Slug = slug
            });
            Console.WriteLine("Categoria atualizada com sucesso");
            Console.ReadKey();
            List();
        }

        private void Delete()
        {
            Console.Clear();
            Console.Write("Id: ");
            var id = int.Parse(Console.ReadLine());
            _service.DeleteCategory(id);
            Console.WriteLine("Categoria excluidas com sucesso");
            Console.ReadKey();
            List();
        }
    }
}