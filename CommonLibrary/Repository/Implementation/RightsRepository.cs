using CommonLibrary.Repository.DBContext;
using CommonLibrary.Repository.Interface;
using CommonLibrary.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Repository.Implementation
{
    public class RightsRepository : GenericRepository<Rights>, IRightsRepository
    {
        public RightsRepository(ProjectManagementTrackerDBContext context) : base(context)
        {
        }
    }
}
