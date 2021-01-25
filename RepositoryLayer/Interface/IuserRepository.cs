using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IuserRepository
    {
        userRegistration addUser(userRegistration UserData);
        userRegistration loginUser(userRegistration UserData);


    }
}
