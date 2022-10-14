using CommonLibrary.BusinessLogic.Interface;
using CommonLibrary.BusinessLogic.Models;
using CommonLibrary.Repository.Interface;
using CommonLibrary.Repository.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary.BusinessLogic.Implementation
{
    public class TaskBusiness : ITaskBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<TaskBusiness> _logger;

        public TaskBusiness(IUnitOfWork unitOfWork, ILogger<TaskBusiness> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public bool AddTask(SaveTask taskDetails)
        {
            try
            {
                _logger.LogInformation($"Adding task. Task Name: {taskDetails.TaskName}");
                Task task = new Task { 
                    TaskName = taskDetails.TaskName,
                    Deliverables = taskDetails.Deliverables,
                    StartDate = taskDetails.StartDate,
                    EndDate = taskDetails.EndDate,
                    UserId = taskDetails.UserId
                };
                _unitOfWork.Tasks.Add(task);
                return _unitOfWork.Complete() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<TaskDetails> GetTasks(int userid)
        {
            try
            {
                _logger.LogInformation($"Getting All task details for the userid. UserId: {userid}");
                var tasks = from task in _unitOfWork.Tasks.GetAll() 
                               join u in _unitOfWork.Users.GetAll() on task.UserId equals u.UserId

                               select new TaskDetails
                               {
                                   TaskName = task.TaskName,
                                   TaskStartDate = task.StartDate,
                                   TaskEndDate = task.EndDate,
                                   ProjectStartDate = u.StartDate,
                                   ProjectEndDate = u.EndDate,
                                   AllowcationPercentage = u.AllowcationPercentage,
                                   Deliverables = task.Deliverables
                               };
                return tasks;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
