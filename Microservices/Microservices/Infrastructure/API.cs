using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Infrastructure
{
    public static class API
    {
        public static class Task 
        {
            public static string GetAllTasks(string baseUri)
            {
                return baseUri;
            }

            public static string AddTask(string baseUri)
            {
                return baseUri + "/create";
            }

            public static string DeleteTask(string baseUri)
            {
                return baseUri + "/delete";
            }
        }
    }
}
