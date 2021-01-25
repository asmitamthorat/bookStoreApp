using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Interface
{
    public interface IuserService
    {
        userRegistration addUser(userRegistration userData);

        string loginUser(userRegistration userData);
    }
}
