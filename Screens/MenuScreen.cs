using System;

namespace BlogExample.Screens
{
    public static class MenuScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("MENU PRINCIPAL");
            Console.WriteLine("--------------");
            Console.WriteLine("");
            Console.WriteLine("1 - Categoria");
            Console.WriteLine("2 - Posts");
            Console.WriteLine("3 - Tags");
            Console.WriteLine("4 - Usuários");
            Console.WriteLine("5 - Perfis");
            Console.WriteLine("9 - Sair");
            Console.WriteLine("");
            Console.Write("Selecione a opção: ");
            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    var category = new CategoryScreen();
                    category.Load();
                    break;
                case 2:
                    var post = new PostScreen();
                    post.Load();
                    break;
                case 3:
                    var tag = new TagScreen();
                    tag.Load();
                    break;
                case 4:
                    var user = new UserScreen();
                    user.Load();
                    break;
                case 5:
                    var role = new RoleScreen();
                    role.Load();
                    break;
            }
        }
    }
}