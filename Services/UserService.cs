using System.Collections.Generic;
using BlogExample.Models;
using BlogExample.Repositories;
using Microsoft.Data.SqlClient;

namespace BlogExample.Services
{
    public class UserService
    {
        private UserRepository _repository;

        public UserService(SqlConnection connection)
            => _repository = new UserRepository(connection);

        public IEnumerable<User> GetUsers()
            => _repository.GetAll();

        public User GetUser(int Id)
            => _repository.Get(Id);

        public void CreateUser(User user)
            => _repository.Create(user);

        public void UpdateUser(User user)
            => _repository.Update(user);

        public void DeleteUser(User user)
            => _repository.Delete(user);

        public void DeleteUser(int id)
            => _repository.Delete(id);

        public List<User> GetUserWithRoles()
            => _repository.GetWhitRoles();
    }
}