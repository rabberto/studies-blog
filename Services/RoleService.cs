using System.Collections;
using System.Collections.Generic;
using BlogExample.Models;
using BlogExample.Repositories;
using Microsoft.Data.SqlClient;

namespace BlogExample.Services
{
    public class RoleService
    {
        private readonly Repository<Role> _repository;

        public RoleService(SqlConnection connection)
            => _repository = new Repository<Role>(connection);

        public IEnumerable<Role> GetRoles()
            => _repository.GetAll();

        public Role GetRole(int id)
            => _repository.Get(id);

        public void CreateRole(Role role)
            => _repository.Create(role);

        public void UpdateRole(Role role)
            => _repository.Update(role);

        public void DeleteRole(Role role)
            => _repository.Delete(role);

        public void DeleteRole(int id)
            => _repository.Delete(id);

    }
}