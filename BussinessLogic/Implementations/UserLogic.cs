using BussinessLogic.Abstractions;
using DataAccess.Abstractions;
using Entities.Entities;
using Microsoft.Extensions.Options;
using Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BussinessLogic.Implementations
{
    public class UserLogic : IUserLogic
    {
        private IUserRepository _userRepository;
        private readonly AppSettings _appSettings;

        public UserLogic(IUserRepository userRepository, IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
        }

        public User Add(User entity)
        {
            _userRepository.Create(entity);
            _userRepository.Commit();
            return entity;
        }

        public void Delete(User entity)
        {
            _userRepository.Delete(entity.Id);
            _userRepository.Commit();
        }

        public User Update(User entity)
        {
            _userRepository.Update(entity);
            _userRepository.Commit();
            return entity;
        }

        public User Find(User entity)
        {
            return _userRepository.GetById(entity.Id);
        }

        public User GetByFilter(Expression<Func<User, bool>> filter)
        {
            return _userRepository.GetByFilter(filter);
        }

        public ICollection<User> GetAll()
        {
            return _userRepository.GetAll();
        }
    }
}