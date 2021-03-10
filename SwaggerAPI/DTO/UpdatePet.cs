using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerAPI.DTO
{
    public class UpdatePet
    {
        
            public long Id { get; set; }            
            public string Name { get; set; }
            public string[] PhotoUrls { get; set; }
            public Category[] Tags { get; set; }
            public string Status { get; set; }
        

        public partial class Category
        {
            public long Id { get; set; }
            public string Name { get; set; }
        }
    }
}
