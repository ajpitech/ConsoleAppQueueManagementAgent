using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppQueueManagementUser
{
    
    public class OutResponse<T>
    {
        public int ResCode { get; set; }
        public string ResMessage { get; set; }

        public T ResData { get; set; }
    }
}
