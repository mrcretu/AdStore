using BussinessLogic.Abstractions;
using DataAccess.Abstractions;
using Entities.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Service.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;

namespace BussinessLogic.Implementations
{
    public class UserLogic : ILogic<User>
    {
        private IUserRepository _userRepository;
        private readonly AppSettings _appSettings;

        public UserLogic(IUserRepository userRepository, IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
        }

        public User Authenticate(string username, string password)
        {
            var users = _userRepository.GetAll();
            var user = users.SingleOrDefault(u => u.Username == username && u.Password == password);

            if (user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user;
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