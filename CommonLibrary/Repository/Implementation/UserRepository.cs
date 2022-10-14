using CommonLibrary.Repository.DBContext;
using CommonLibrary.Repository.Interface;
using CommonLibrary.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Repository.Implementation
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ProjectManagementTrackerDBContext context) : base(context) { 
        }
    }
}
