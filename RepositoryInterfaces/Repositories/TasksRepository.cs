using DomainEntities.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Repositories
{
    public class TasksRepository : GenericRepository<tblTask>, ITasksRepository
    {

        public TasksRepository(WebApiDBEntities dBEntities) : base(dBEntities)
        {


        }


        public void PutTask(int id, tblTask task)
        {
            using (var db = new WebApiDBEntities())
            {
                var result = db.tblTasks.SingleOrDefault(t => t.ID == id);
                if (result != null)
                {
                    result.Content = task.Content;
                    result.TaskType = task.TaskType;
                }
                db.SaveChanges();
            }
        }




        public void PatchTask(int id, tblTask task)
        {
            using (var db = new WebApiDBEntities())
            {
                var result = db.tblTasks.SingleOrDefault(t => t.ID == id);
                
                if (result != null)
                {
                    var target = task.Content;
                    if (target != null)
                    {
                        result.Content = target;
                    }

                    var target2 = task.TaskType;
                    if (target2 != null)
                    {
                        result.TaskType = target2;
                    }
                }
                db.SaveChanges();
            }
        }
    }
}