using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceInterfaces.DataTransferObjects
{
    public class UserDTO
    {
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string UserPassword { get; set; }

        public string UserRoles { get; set; }

        public string UserEmailID{ get; set; }

    }
}
