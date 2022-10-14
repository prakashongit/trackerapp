using CommonLibrary.BusinessLogic.Interface;
using CommonLibrary.BusinessLogic.Models;
using CommonLibrary.Extensions;
using CommonLibrary.Repository.Interface;
using CommonLibrary.Repository.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary.BusinessLogic.Implementation
{
    public class ProjectBusiness : IProjectBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ProjectBusiness> _logger;

        public ProjectBusiness(IUnitOfWork unitOfWork, ILogger<ProjectBusiness> logger) 
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public bool AddProject(ProjectDetails projectDetails)
        {
            try
            {
                _logger.LogInformation($"Check the project name already exists. Project Name: {projectDetails.ProjectName}");
                var existingProject = _unitOfWork.Projects.Find(p => p.ProjectName.ToUpper().Equals(projectDetails.ProjectName)).FirstOrDefault();

                if (existingProject == null)
                {
                    _logger.LogInformation($"Adding project. Project Name: {projectDetails.ProjectName}");
                    Project project = new Project { ProjectName = projectDetails.ProjectName, Description = projectDetails.Description };
                    _unitOfWork.Projects.Add(project);
                    return _unitOfWork.Complete() > 0;
                }
                else {
                    Exception ex = new Exception("Project Already Exists");
                    _logger.LogErrorDetails(ex);
                    throw ex;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ProjectDetails> GetProjects()
        {
            try
            {
                _logger.LogInformation("Getting All project details.");
                var projects = from project in _unitOfWork.Projects.GetAll()
                               select new ProjectDetails
                               {
                                   ProjectId = project.ProjectId,
                                   ProjectName = project.ProjectName,
                                   Description = project.Description
                               };
                return projects;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool UpdateAllowcationPercentage(UpdatePercentage details)
        {
            _logger.LogInformation($"Updating allocation percentage for the user");
            try
            {
                var user = _unitOfWork.Users.GetById(details.UserId);
                if (user == null)
                    throw new Exception("User not found");
                _logger.LogInformation("updating allocation percentage");
                user.AllowcationPercentage = details.AllocationPercentage;
                _unitOfWork.Users.Update(user);
                _unitOfWork.Complete();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return true;
        }
    }
}
