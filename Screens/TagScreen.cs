using System;
using BlogExample.Models;
using BlogExample.Services;

namespace BlogExample.Screens
{
    public class TagScreen
    {
        private TagService _service;
        public TagScreen()
            => _service = new TagService(Database.Connection);

        public void Load()
        {
            Console.Clear();
            Console.WriteLine("GESTÃO DE TAGS");
            Console.WriteLine("--------------------");
            Console.WriteLine("");
            Console.WriteLine("1 - Listar Tags");
            Console.WriteLine("2 - Cadastrar Tag");
            Console.WriteLine("3 - Atualizar Tag");
            Console.WriteLine("4 - Excluir Tag");
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

            var tags = _service.GetTags();
            foreach (var tag in tags)
                Console.WriteLine($"{tag.Id} - {tag.Name} ({tag.Slug})");

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
            _service.CreateTag(new Tag
            {
                Name = name,
                Slug = slug
            });
            Console.WriteLine("Tag cadastrada com sucesso");
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
            _service.UpdateTag(new Tag
            {
                Id = id,
                Name = name,
                Slug = slug
            });
            Console.WriteLine("Tag atualizada com sucesso");
            Console.ReadKey();
            List();
        }

        private void Delete()
        {
            Console.Clear();
            Console.Write("Id: ");

            _service.DeleteTag(int.Parse(Console.ReadLine()));

            Console.WriteLine("Tag excluidas com sucesso");
            Console.ReadKey();
            List();
        }
    }
}