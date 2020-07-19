using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Domain.Entities
{
    public class Blog
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public List<Tag> TagList { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        
    }
}
