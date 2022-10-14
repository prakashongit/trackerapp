using CommonLibrary.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.BusinessLogic.Interface
{
    public interface ITaskBusiness
    {
        bool AddTask(SaveTask task);
        IEnumerable<TaskDetails> GetTasks(int userid);
    }
}
