using CommonLibrary.Repository.DBContext;
using CommonLibrary.Repository.Interface;
using CommonLibrary.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Repository.Implementation
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(ProjectManagementTrackerDBContext context) : base(context)
        {
        }
    }
}