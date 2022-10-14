using CommonLibrary.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.BusinessLogic.Interface
{
    public interface IUserBusiness
    {
        IEnumerable<UserDetails> GetMyUsers(int managerId);
        string GetToken(LoginDetails loginDetails);
        bool CreateUser(Registration user, bool isAdmin = true);
    }
}
