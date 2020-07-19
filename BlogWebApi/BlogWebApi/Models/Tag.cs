using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebApi.Models
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string TagName { get; set; }
    }
}
