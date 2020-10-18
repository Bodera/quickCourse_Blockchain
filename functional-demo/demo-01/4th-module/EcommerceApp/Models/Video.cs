using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Models
{
    public class Video
    {
        public int Id {get; set;}
        public string Title {get; set;}
        public string URL {get; set;}
        public string Image {get; set;}
        public decimal Price {get; set;}
        public virtual List<User> Users {get; set;}
    }

    public static class ListVideo
    {
        public static List<Video> Videos()
        {
            var catalogue = new List<Video>
            {
                new Video { Id = 1, Title = "Trip Request", URL = "58rXvxcvovc", Image = "", Price = 2 },
                new Video { Id = 2, Title = "Nuclear Bombs", URL = "SHZAaGidUbg", Image = "", Price = 4 },
                new Video { Id = 3, Title = "Intro to COBOL", URL = "ycHXzbAmY94", Image = "", Price = 6 }
            };
            return catalogue;
        }
    }
}