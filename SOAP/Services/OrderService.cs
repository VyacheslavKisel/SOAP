using Microsoft.EntityFrameworkCore;
using SOAP.Database;
using SOAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOAP.Services
{
    public class OrderService : IOrderService
    {
        private readonly DatabaseContext _context;

        public OrderService(DatabaseContext context)
        {
            _context = context;

            if(!_context.Orders.Any())
            {
                for (int i = 0; i < 5; i++)
                {
                    var temp = i + 1;

                    var order = new Order
                    {
                        Id = temp,
                        Name = "Abc " + temp.ToString(),
                        Email = "abc.def" + temp.ToString() + "@gmail.com",
                        RoomId = 100 + temp
                    };

                    context.Orders.Add(order);
                }

                context.SaveChanges();
            }
        }

        public Order GetOrder(int id)
        {
            var order = _context.Orders.Find(id);

            return order;
        }

        public IEnumerable<Order> GetOrders()
        {
            var orders = _context.Orders;

            return orders;
        }

        public bool AddOrder(Order order)
        {
            _context.Add(order);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateOrder(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            _context.SaveChanges();

            return true;
        }

        public bool DeleteOrder(int id)
        {
            var room = _context.Orders.Find(id);

            _context.Entry(room).State = EntityState.Deleted;
            _context.SaveChanges();

            return true;
        }
    }
}
