using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookStore.Models
{
    public class EFStoreRepository : IBookRepository
    {
        private MBS_DBContext context;
        public EFStoreRepository(MBS_DBContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Book> Books => context.Books;
    }
}
