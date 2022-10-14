using CommonLibrary.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.BusinessLogic.Interface
{
    public interface IProjectBusiness
    {
        bool AddProject(ProjectDetails project);
        IEnumerable<ProjectDetails> GetProjects();
        bool UpdateAllowcationPercentage(UpdatePercentage details);
    }
}
