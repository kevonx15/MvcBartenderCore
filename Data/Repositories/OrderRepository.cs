using MvcBartender.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcBartender.Data.Models;


namespace MvcBartender.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MyAppDbContext _myAppDbContext;
        private readonly ShoppingCart _shoppingCart;


        public OrderRepository(MyAppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _myAppDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }


        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            _myAppDbContext.Orders.Add(order);

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = shoppingCartItem.Amount,
                    DrinkId = shoppingCartItem.Drink.DrinkId,
                    OrderId = order.OrderId,
                    Price = shoppingCartItem.Drink.Price
                };

                _myAppDbContext.OrderDetails.Add(orderDetail);
            }

            _myAppDbContext.SaveChanges();
        }
    }
}
