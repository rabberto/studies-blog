using System;
using BlogExample.Models;
using BlogExample.Services;

namespace BlogExample.Screens
{
    public class RoleScreen
    {
        private RoleService _service;

        public RoleScreen()
            => _service = new RoleService(Database.Connection);

        public void Load()
        {
            Console.Clear();
            Console.WriteLine("GESTÃO DE PERIS");
            Console.WriteLine("--------------------");
            Console.WriteLine("");
            Console.WriteLine("1 - Listar Perfis");
            Console.WriteLine("2 - Cadastrar Perfil");
            Console.WriteLine("3 - Atualizar Perfil");
            Console.WriteLine("4 - Excluir Perfil");
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

            var roles = _service.GetRoles();
            foreach (var role in roles)
                Console.WriteLine($"{role.Id} - {role.Name} ({role.Slug})");

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
            _service.CreateRole(new Role
            {
                Name = name,
                Slug = slug
            });
            Console.WriteLine("Perfil cadastrado com sucesso");
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
            _service.UpdateRole(new Role
            {
                Id = id,
                Name = name,
                Slug = slug
            });
            Console.WriteLine("Perfil atualizado com sucesso");
            Console.ReadKey();
            List();
        }

        private void Delete()
        {
            Console.Clear();
            Console.Write("Id: ");

            _service.DeleteRole(int.Parse(Console.ReadLine()));

            Console.WriteLine("Perfil excluido com sucesso");
            Console.ReadKey();
            List();
        }
    }
}