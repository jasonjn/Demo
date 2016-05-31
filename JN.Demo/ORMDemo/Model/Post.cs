using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMDemo.Model
{
    class Post
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Slug { get; set; }

        public string Title { get; set; }

        public DateTime Published { get; set;}

        public string Excerpt { get; set; }

        public  string Content { get; set; }

    }
}
