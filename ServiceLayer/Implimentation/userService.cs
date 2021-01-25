using ModelLayer;
using RepositoryLayer.Interface;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Implimentation
{
    public class userService:IuserService
    {
        private IuserRepository _repository;
        public userService(IuserRepository repository)
        {
            _repository = repository;

        }
       
        public userRegistration addUser(userRegistration userData) {
            userRegistration result = _repository.addUser(userData);
            return result;
        }

        public userRegistration loginUser(userRegistration userData) {
            userRegistration result = _repository.loginUser(userData);
            return result;
        }


    }
}
