using System.Collections.Generic;
using BlogExample.Models;
using BlogExample.Repositories;
using Microsoft.Data.SqlClient;

namespace BlogExample.Services
{
    public class CategoryService
    {

        private readonly Repository<Category> _repository;

        public CategoryService(SqlConnection connection)
            => _repository = new Repository<Category>(connection);

        public IEnumerable<Category> GetCategories()
            => _repository.GetAll();

        public Category GetCategory(int id)
            => _repository.Get(id);

        public void CreateCategory(Category category)
            => _repository.Create(category);

        public void UpdateCategory(Category category)
            => _repository.Update(category);

        public void DeleteCategory(Category category)
            => _repository.Delete(category);

        public void DeleteCategory(int id)
            => _repository.Delete(id);
    }
}