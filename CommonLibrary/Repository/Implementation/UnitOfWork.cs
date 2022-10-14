using CommonLibrary.Repository.DBContext;
using CommonLibrary.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Repository.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ProjectManagementTrackerDBContext _context;

        public IRoleRepository Roles { get; private set; }

        public IUserRepository Users { get; private set; }

        public IRightsRepository Rights { get; private set; }
        public IProjectRepository Projects { get; private set; }
        public ITaskRepository Tasks { get; private set; }

        public UnitOfWork(ProjectManagementTrackerDBContext context) {
            _context = context;
            Roles = new RoleRepository(context);
            Users = new UserRepository(context);
            Rights = new RightsRepository(context);
            Projects = new ProjectRepository(context);
            Tasks = new TaskRepository(context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
