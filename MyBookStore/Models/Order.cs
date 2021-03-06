using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static MyBookStore.Models.Cart;


namespace MyBookStore.Models
{
    public class Order
    {
        [BindNever]
        public int OrderID { get; set; }

        [BindNever]
        public ICollection<CartLine> CartLines { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter an Address Line")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        [Required(ErrorMessage = "Please enter a City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter a State/Province")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter a Postal Code")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Please enter a Country")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please enter an Address Line")]
        public bool GiftWrap { get; set; }
    }

}
