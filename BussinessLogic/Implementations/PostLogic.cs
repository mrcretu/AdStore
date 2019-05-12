using BussinessLogic.Abstractions;
using DataAccess.Abstractions;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BussinessLogic.Implementations
{
    public class PostLogic : IPostLogic
    {
        private readonly IPostRepository _postRepository;

        public PostLogic(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public Post Add(Post entity)
        {
            _postRepository.Create(entity);
            _postRepository.Commit();
            return entity;
        }

        public void Delete(Post entity)
        {
            _postRepository.Delete(entity.Id);
            _postRepository.Commit();
        }

        public Post Find(Post entity)
        {
            return _postRepository.GetById(entity.Id);
        }

        public ICollection<Post> GetAll()
        {
            return _postRepository.GetAll();
        }

        public Post GetByFilter(Expression<Func<Post, bool>> filter)
        {
            return _postRepository.GetByFilter(filter);
        }

        public Post Update(Post entity)
        {
            _postRepository.Update(entity);
            _postRepository.Commit();
            return entity;
        }
    }
}
