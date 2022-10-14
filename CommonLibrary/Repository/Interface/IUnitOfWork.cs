using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Repository.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IRoleRepository Roles { get; }
        IUserRepository Users { get; }
        IRightsRepository Rights { get; }
        IProjectRepository Projects { get; }
        ITaskRepository Tasks { get; }
        int Complete();
    }
}
