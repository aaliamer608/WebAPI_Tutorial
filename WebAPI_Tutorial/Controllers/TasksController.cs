using AutoMapper;
using ServiceInterfaces.DataTransferObjects;
using ServiceInterfaces.DataViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_Tutorial;


namespace WebAPI_Tutorial.Controllers
{
    public class TasksController : ApiController
    {

        MapperConfiguration config;
        IMapper mapper;
        TaskService taskService;


        public TasksController()
        {
            taskService = new TaskService();
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TaskDTO, TaskService>();
                cfg.CreateMap<TaskService, TaskDTO>();
                //cfg.CreateMap
            });
            mapper = config.CreateMapper();
        }
        //GET All tasks
        [HttpGet]
        public IEnumerable<TaskDTO> GetTasks()
        {
            return taskService.GetAllTasks();
        }

        //GET Task by id
        [HttpGet]
        public IEnumerable<TaskDTO> GetTasksByID(int id)
        {
            return taskService.GetTaskByID(id);
        }

        //DELETE Task
        [HttpDelete]
        public HttpResponseMessage DeleteTask(int id)
        {
            var target = taskService.GetTaskByID(id);

            try
            {
                if (target != null)
                {
                    taskService.DeleteTask(id);
                    return Request.CreateResponse(HttpStatusCode.OK);

                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "Task with Id = " + id.ToString() + " not found to delete");

                }
            }

            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //POST Task
        [HttpPost]
        public void PostTask([FromBody] TaskDTO taskModel)
        {
            TaskDTO taskDTO = mapper.Map<TaskDTO>(taskModel);
            taskService.PostTask(taskDTO);
        }

        //PUT Task
        [HttpPut]
        public HttpResponseMessage PutTask(int id, [FromBody] TaskDTO taskModel)
        {
            try
            {


                if (taskModel == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "Employee with Id " + id.ToString() + " not found to update");
                }
                else
                {
                    taskService.PutTask(id, taskModel);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        //PATCH Task
        [HttpPatch]
        public IHttpActionResult PatchTask([FromUri] int id, [FromBody] TaskService taskModel)
        {
            if (taskModel == null)
            {
                return BadRequest("Nothing To Patch");

            }
            else
            {
                TaskDTO taskDTO = mapper.Map<TaskDTO>(taskModel);
                taskService.PatchTask(id, taskDTO);
                return Ok(taskService.GetTaskByID(id));

            }
        }
    }
}