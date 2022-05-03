using RepositoryInterfaces;
using DomainEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceInterfaces.DataTransferObjects;

namespace ServiceInterfaces.DataViewModel
{
    public class TaskService
    {
        public UnitOfWork uow { get; set; }

        public WebApiDBEntities dBEntities;

        public TaskService()
        {
            this.dBEntities = new WebApiDBEntities();
            this.uow = new UnitOfWork(dBEntities);
        }

        public List<TaskDTO> getAllTasks()
        {
            IEnumerable<tblTask> tasks = uow.Tasks.GetAll();
            List<TaskDTO> results = new List<TaskDTO>();

            foreach (tblTask task in tasks)
            {
                TaskDTO taskDTO = new TaskDTO()
                {
                    ID = task.ID,
                    //UserID = (int)task.UserID,
                    Content = task.Content
                };
                results.Add(taskDTO);
            }
            uow.Complete();

            return results;
        }




        public IEnumerable<TaskDTO> getTaskByID(int id)
        {
            var tasks = uow.Tasks.GetAll();

            var result = (
                from t in tasks
                where t.ID.Equals(id)
                select new TaskDTO
                {
                    ID = t.ID,
                    Content = t.Content
                }).ToList();

            uow.Complete();

            return result;
        }
    }
}
