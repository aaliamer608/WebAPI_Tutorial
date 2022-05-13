using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceInterfaces.DataTransferObjects
{
    public class QuoteDTO
    {
        public int Quote_ID { get; set; }
        public string Quote_Type { get; set; }
        public string Contact_Name { get; set; }
        public string Task_Type { get; set; }
        public DateTime DueDate{ get; set; }

    }
}
