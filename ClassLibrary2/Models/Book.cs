using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Models
{
    public class Book
    {
        [Key]
        public int id { get; set; }
        public string BookName { get; set; }
        public int Price { get; set; }
    }
}
