using System;
using BlogExample.Models;
using BlogExample.Services;

namespace BlogExample.Screens
{
    public class UserScreen
    {
        private UserService _service;
        public UserScreen()
         => _service = new UserService(Database.Connection);

        public void Load()
        {
            Console.Clear();
            Console.WriteLine("GESTÃO DE USUÁRIOS");
            Console.WriteLine("--------------------");
            Console.WriteLine("");
            Console.WriteLine("1 - Listar Usuários");
            Console.WriteLine("2 - Cadastrar Usuário");
            Console.WriteLine("3 - Atualizar Usuário");
            Console.WriteLine("4 - Excluir Usuário");
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
            foreach (var user in _service.GetUsers())
                Console.WriteLine($"{user.Id} - {user.Name} {user.Email} ({user.Slug}) ");

            Console.ReadKey();
            Load();
        }

        private void Create()
        {
            Console.Clear();
            Console.Write("Nome: ");
            var name = Console.ReadLine();
            Console.Write("Email: ");
            var email = Console.ReadLine();
            Console.Write("Senha: ");
            var passwordHash = Console.ReadLine();
            Console.Write("Biografia: ");
            var bio = Console.ReadLine();
            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            _service.CreateUser(new User
            {
                Name = name,
                Email = email,
                PasswordHash = passwordHash,
                Bio = bio,
                Slug = slug
            });

            Console.WriteLine("Usuário cadastrado com sucesso");
            Console.ReadKey();
        }

        private void Update()
        {
            Console.Clear();
            Console.Write("Id: ");
            var id = int.Parse(Console.ReadLine());
            Console.Write("Nome: ");
            var name = Console.ReadLine();
            Console.Write("Email: ");
            var email = Console.ReadLine();
            Console.Write("Senha: ");
            var passwordHash = Console.ReadLine();
            Console.Write("Biografia: ");
            var bio = Console.ReadLine();
            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            _service.CreateUser(new User
            {
                Name = name,
                Email = email,
                PasswordHash = passwordHash,
                Bio = bio,
                Slug = slug
            });

            Console.WriteLine("Usuário cadastrado com sucesso");
            Console.ReadKey();
        }

        private void Delete()
        {
            Console.Clear();
            Console.Write("Id: ");

            _service.DeleteUser(int.Parse(Console.ReadLine()));

            Console.WriteLine("Usuário excluido com sucesso");
            Console.ReadKey();
        }
    }
}