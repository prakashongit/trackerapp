using CommonLibrary.Repository.DBContext;
using CommonLibrary.Repository.Interface;
using CommonLibrary.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Repository.Implementation
{
    class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ProjectManagementTrackerDBContext context) : base(context)
        {
        }
    }
}
