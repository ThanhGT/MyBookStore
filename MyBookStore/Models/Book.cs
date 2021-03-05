using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

/* Models a book that contains bookID, name, description, price and category **/

namespace MyBookStore.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName ="decimal(8,2")]
        public decimal Price { get; set; }
        public string  Category { get; set; }
    }
}
