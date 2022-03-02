using System.Collections.Generic;
using BlogExample.Models;
using BlogExample.Repositories;
using Microsoft.Data.SqlClient;

namespace BlogExample.Services
{
    public class TagService
    {
        private Repository<Tag> _repository;
        public TagService(SqlConnection connection)
            => _repository = new Repository<Tag>(connection);

        public IEnumerable<Tag> GetTags()
            => _repository.GetAll();

        public Tag GetTag(int id)
            => _repository.Get(id);

        public void CreateTag(Tag tag)
            => _repository.Create(tag);

        public void UpdateTag(Tag tag)
            => _repository.Update(tag);

        public void DeleteTag(Tag tag)
            => _repository.Delete(tag);

        public void DeleteTag(int id)
            => _repository.Delete(id);


    }
}