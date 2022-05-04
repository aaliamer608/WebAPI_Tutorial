using RepositoryInterfaces;
using DomainEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceInterfaces.DataTransferObjects;
using AutoMapper;

namespace ServiceInterfaces.DataViewModel
{
    public class TaskService
    {
        public UnitOfWork uow { get; set; }

        public WebApiDBEntities dBEntities;

        MapperConfiguration config;
        IMapper mapper;

        public TaskService()
        {
            this.dBEntities = new WebApiDBEntities();
            this.uow = new UnitOfWork(dBEntities);

            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<tblTask, TaskDTO>();
                cfg.CreateMap<TaskDTO, tblTask>();
            }
            );
            mapper = config.CreateMapper();
        }

        public List<TaskDTO> GetAllTasks()
        {
            IEnumerable<tblTask> tasks = uow.Tasks.GetAll();
            List<TaskDTO> results = new List<TaskDTO>();

            foreach (tblTask task in tasks)
            {
                TaskDTO taskDTO = new TaskDTO()
                {
                    ID = task.ID,
                    Content = task.Content
                };
                results.Add(taskDTO);
            }
            uow.Complete();

            return results;
        }




        public IList<TaskDTO> GetTaskByID(int id)
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



        public TaskDTO DeleteTask(int id)
        {
            tblTask foundTask = uow.Tasks.GetById(id);
            if (foundTask != null)
            {
                uow.Tasks.Remove(foundTask);
                uow.Complete();
                return mapper.Map<TaskDTO>(foundTask);
            }
            else
            {
                return null;
            }
        }

        public void PostTask(TaskDTO taskDTO)
        {
            tblTask task = mapper.Map<tblTask>(taskDTO);
            uow.Tasks.Add(task);
            uow.Complete();
        }


        public void PutTask(int id, TaskDTO taskDTO)
        {
            uow.Tasks.PutTask(id, mapper.Map<tblTask>(taskDTO));
        }



        public void PatchTask(int id, TaskDTO taskDTO)
        {
            uow.Tasks.PatchTask(id, mapper.Map<tblTask>(taskDTO));
        }
    }
}
