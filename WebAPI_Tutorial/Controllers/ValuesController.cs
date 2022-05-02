using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_Tutorial.Models;

namespace WebAPI_Tutorial.Controllers
{
    public class ValuesController : ApiController
    {

        //GET ALL USERS
        public IEnumerable<UserMaster> GetTblUser()
        {
            using (WebApiDBEntities dbContext = new WebApiDBEntities())
            {
                return dbContext.UserMasters.ToList();
            }
        }

        //GET USER BY ID
        public UserMaster GetTblUserByID(int id)
        {
            using (WebApiDBEntities dbContext = new WebApiDBEntities())
            {
                return dbContext.UserMasters.FirstOrDefault(e => e.UserID == id);
            }
        }



        //GET ALL TASKS
        public IEnumerable<tblTask> GetTblTask()
        {
            using (WebApiDBEntities dBEntities = new WebApiDBEntities())
            {
                return dBEntities.tblTasks.ToList();
            }
        }



        //GET TASK BY ID
        public tblTask GetTblTaskByID(int id)
        {
            using (WebApiDBEntities dBEntities = new WebApiDBEntities())
            {
                return dBEntities.tblTasks.FirstOrDefault(e => e.ID == id);
            }
        }

        //POST NEW USER
        public HttpResponseMessage PostTblUser([FromBody] UserMaster user)
        {
            try
            {
                using (WebApiDBEntities dbContext = new WebApiDBEntities())
                {
                    dbContext.UserMasters.Add(user);
                    dbContext.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, user);
                    message.Headers.Location = new Uri(Request.RequestUri +
                        user.UserID.ToString());

                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //POST NEW TASK
        public HttpResponseMessage PostTblTask([FromBody] tblTask task)
        {
            try
            {
                using (WebApiDBEntities dbContext = new WebApiDBEntities())
                {
                    dbContext.tblTasks.Add(task);
                    dbContext.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, task);
                    message.Headers.Location = new Uri(Request.RequestUri +
                        task.ID.ToString());

                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        // PUT (UPDATE) USER
        public HttpResponseMessage PutUser(int id, [FromBody] UserMaster user)
        {
            try
            {
                using (WebApiDBEntities dbContext = new WebApiDBEntities())
                {
                    var entity = dbContext.UserMasters.FirstOrDefault(e => e.UserID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "User with Id " + id.ToString() + " not found to update");
                    }
                    else
                    {
                        entity.UserID = user.UserID;
                        entity.UserName = user.UserName;
                        entity.UserPassword = user.UserPassword;
                        entity.UserRoles = user.UserRoles;
                        entity.UserEmailID = user.UserEmailID;

                        dbContext.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }



        // PUT (UPDATE) TASK
        public HttpResponseMessage PutTask(int id, [FromBody] tblTask task)
        {
            try
            {
                using (WebApiDBEntities dbContext = new WebApiDBEntities())
                {
                    var entity = dbContext.tblTasks.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Task with Id " + id.ToString() + " not found to update");
                    }
                    else
                    {
                        entity.ID = task.ID;
                        entity.Content = task.Content;
                        entity.UserID = task.UserID;

                        dbContext.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }



        // DELETE User
        public HttpResponseMessage DeleteUser(int id)
        {
            try
            {
                using (WebApiDBEntities dbContext = new WebApiDBEntities())
                {
                    var entity = dbContext.UserMasters.FirstOrDefault(e => e.UserID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "User with Id = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        dbContext.UserMasters.Remove(entity);
                        dbContext.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        public HttpResponseMessage DeleteTask(int id)
        {
            try
            {
                using (WebApiDBEntities dbContext = new WebApiDBEntities())
                {
                    var entity = dbContext.tblTasks.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Task with Id = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        dbContext.tblTasks.Remove(entity);
                        dbContext.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        //public void patch
    }
}





