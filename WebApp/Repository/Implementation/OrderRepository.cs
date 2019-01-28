using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Repository
{
    public class OrderRepository : BaseRopository, IOrderRepository
    {
        public OrderRepository(LibraryContext _context)
        {
            context = _context;
        }

        public async Task<Order> AddOrder(Order _order)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var order = (await context.Orders.AddAsync(_order)).Entity;

                    await context.SaveChangesAsync();

                    foreach (var orderService in _order.OrderServices)
                    {
                        await context.OrderServices.AddAsync(new OrderService { OrderId = order.Id, LibrarianId = orderService.LibrarianId, ServiceName = orderService.ServiceName });
                    }

                    await context.SaveChangesAsync();

                    transaction.Commit();
                    return await this.GetOrder(order.Id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    transaction.Rollback();
                    return null;
                }
            }
        }

        public async Task<bool> DeleteOrder(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var order = await context.Orders.FindAsync(id);

                    var orderServices = context.OrderServices.Where(o => o.OrderId == order.Id);
                    context.RemoveRange(orderServices.ToArray());

                    context.Remove(order);

                    await context.SaveChangesAsync();

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public async Task<Order> GetOrder(int id)
        {
            var orders = (IQueryable<Order>)context.Orders;
            orders = from order in orders
                     join customer in context.Users
                     on order.CustomerId equals customer.Id
                     join book in context.Books
                     on order.BookId equals book.Id
                     select new Order
                     {
                         Id = order.Id,
                         BookId = order.BookId,
                         Book = book,
                         CustomerId = order.CustomerId,
                         Customer = customer,
                         OrderDate = order.OrderDate,
                         ExpectedReturnDate = order.ExpectedReturnDate,
                         ReturnDate = order.ReturnDate,
                         OrderServices = context.OrderServices
                                            .Where(orderService => orderService.OrderId == order.Id)
                                            .Join(context.Users, o => o.LibrarianId, l => l.Id,
                                                (o, l) => new OrderService
                                                {
                                                    Id = o.Id,
                                                    LibrarianId = l.Id,
                                                    Librarian = l,
                                                    ServiceName = o.ServiceName,
                                                    OrderId = o.OrderId
                                                }).ToList(),
                     };

            return await Task.Run(() => orders.First(o => o.Id == id));
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserId(int id)
        {
            var orders = (IQueryable<Order>)context.Orders;
            orders = from order in orders
                     where order.CustomerId == id
                     join customer in context.Users
                     on order.CustomerId equals customer.Id
                     join book in context.Books
                     on order.BookId equals book.Id
                     select new Order
                     {
                         Id = order.Id,
                         BookId = order.BookId,
                         Book = book,
                         CustomerId = order.CustomerId,
                         Customer = customer,
                         OrderDate = order.OrderDate,
                         ExpectedReturnDate = order.ExpectedReturnDate,
                         ReturnDate = order.ReturnDate,
                         OrderServices = context.OrderServices
                                            .Where(orderService => orderService.OrderId == order.Id)
                                            .Join(context.Users, o => o.LibrarianId, l => l.Id,
                                                (o, l) => new OrderService
                                                {
                                                    Id = o.Id,
                                                    LibrarianId = l.Id,
                                                    Librarian = l,
                                                    ServiceName = o.ServiceName,
                                                    OrderId = o.OrderId
                                                }).ToList(),
                     };

            return await Task.Run(() => orders);
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            var orders = (IQueryable<Order>)context.Orders;
            orders = from order in orders
                     join customer in context.Users
                     on order.CustomerId equals customer.Id
                     join book in context.Books
                     on order.BookId equals book.Id
                     select new Order
                     {
                         Id = order.Id,
                         BookId = order.BookId,
                         Book = book,
                         CustomerId = order.CustomerId,
                         Customer = customer,
                         OrderDate = order.OrderDate,
                         ExpectedReturnDate = order.ExpectedReturnDate,
                         ReturnDate = order.ReturnDate,
                         OrderServices = context.OrderServices
                                            .Where(orderService => orderService.OrderId == order.Id)
                                            .Join(context.Users, o => o.LibrarianId, l => l.Id,
                                                (o, l) => new OrderService
                                                {
                                                    Id = o.Id,
                                                    LibrarianId = l.Id,
                                                    Librarian = l,
                                                    ServiceName = o.ServiceName,
                                                    OrderId = o.OrderId
                                                }).ToList(),
                     };

            return await Task.Run(() => orders);
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    foreach (var orderService in order.OrderServices)
                    {
                        var _orderService = context.OrderServices.Find(orderService.Id);
                        if (_orderService == null)
                        {
                            await context.OrderServices.AddAsync(new OrderService { OrderId = order.Id, LibrarianId = orderService.LibrarianId, ServiceName = orderService.ServiceName });
                        }
                        else
                        {
                            context.Update(_orderService);
                        }
                    }

                    var _order = context.Orders.Find(order.Id);

                    _order.Id = order.Id;
                    _order.BookId = order.BookId;
                    _order.CustomerId = order.CustomerId;
                    _order.OrderDate = order.OrderDate;
                    _order.ExpectedReturnDate = order.ExpectedReturnDate;
                    _order.ReturnDate = order.ReturnDate;

                    context.Update(_order);

                    await context.SaveChangesAsync();

                    transaction.Commit();
                    return await this.GetOrder(order.Id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    transaction.Rollback();
                    return null;
                }
            }
        }
    }
}
