using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookStore.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        //Add the book to the cart
        public void AddItem(Book book, int quantity)
        {
            //check if book id inside cart matches with book id of the book stored in model class
            CartLine line = Lines
                        .Where(b => b.Book.BookID == book.BookID)
                        .FirstOrDefault();

            //if there is no book in cart than add the book to the cart, else if book already exists then increase the quantity
            if(line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = book,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity = +quantity;
            }
        }

        //remove the book from cart
        public void RemoveLines(Book book)
        {
            Lines.RemoveAll(l => l.Book.BookID == book.BookID);
        }

        //clear all books from cart
        public void Clear() => Lines.Clear();

        public decimal TotalCost() =>
            Lines.Sum(c => c.Book.Price * c.Quantity);

        public class CartLine
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
        }
    }
}
