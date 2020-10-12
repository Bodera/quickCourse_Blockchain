using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Models
{
    public class Ebook
    {
        public int Id {get; set;}
        public string Title {get; set;}
        public string URL {get; set;}
        public string Image {get; set;}
        public decimal Price {get; set;}
        public virtual List<User> Users {get; set;}
    }

    public static class ListEbook
    {
        public static List<Ebook> Ebooks()
        {
            var catalogue = new List<Ebook>
            {
                new Ebook {},
                new Ebook {}
            };
            return catalogue;
        }
    }
}