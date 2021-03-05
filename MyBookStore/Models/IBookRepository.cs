using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookStore.Models
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
    }
}
