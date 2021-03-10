using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerAPI.DTO
{
    public class Pet
    {
        public long id { get; set; }
        public string name { get; set; }
        public string[] photoUrls { get; set; }
        public Category[] tags { get; set; }
        public string status { get; set; }


        public  class Category
        {
            public long id { get; set; }
            public string name { get; set; }
        }
    }
}
