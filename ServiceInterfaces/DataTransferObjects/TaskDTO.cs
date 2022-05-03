using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceInterfaces.DataTransferObjects
{
    public class TaskDTO
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public int UserID { get; set; }
    }
}
