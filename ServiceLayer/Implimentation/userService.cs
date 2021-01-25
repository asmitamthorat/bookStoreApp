using ModelLayer;
using RepositoryLayer.Interface;
using ServiceLayer.Interface;
using ServiceLayer.TokenAuthentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Implimentation
{
    public class userService:IuserService
    {
        private IuserRepository _repository;
        ITokenManager _tokenManager;
        public userService(IuserRepository repository, ITokenManager tokenManager)
        {
            _repository = repository;
            _tokenManager = tokenManager;

        }
       
        public userRegistration addUser(userRegistration userData) {
            userRegistration result = _repository.addUser(userData);
            return result;
        }

        public string loginUser(userRegistration userData) {
            userRegistration result = _repository.loginUser(userData);
            string token = _tokenManager.GenerateToken(result);
            return token;
        }


    }
}
