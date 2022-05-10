using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.DataAccess.Response
{
    public class ApiResponse
    {
        public Boolean success { get; set; }
        public String message { get; set; }
        public Object data { get; set; }
        public int count { get; set; }

        public ApiResponse(Boolean success, String message)
        {
            this.success = success;
            this.message = message;
        }


        public ApiResponse(Boolean success, String message, Object data)
        {
            this.success = success;
            this.message = message;
            this.data = data;
        }

        public ApiResponse(Boolean success, String message, Object data, int count)
        {
            this.success = success;
            this.message = message;
            this.data = data;
            this.count = count;
        }

    }
}
