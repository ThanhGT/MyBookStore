using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookStore.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private MBS_DBContext context;
        public EFOrderRepository(MBS_DBContext dbContext)
        {
            context = dbContext;
        }

        public IQueryable<Order> Orders => context.Orders
                                            .Include(o => o.CartLines)
                                            .ThenInclude(b => b.Book);

        public void SaveOrder(Order order)
        {
            // checks if an ongoing session is still in progress and prevents any new sessions to overwrite anything in the d
            context.AttachRange(order.CartLines.Select(b=> b.Book));
            if(order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}
