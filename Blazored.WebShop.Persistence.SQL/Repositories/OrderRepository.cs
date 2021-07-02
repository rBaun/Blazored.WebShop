using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazored.WebShop.Application.Plugins.Persistence;
using Blazored.WebShop.Core.Business.Models;
using Blazored.WebShop.Persistence.SQL.Wrappers.Interfaces;

namespace Blazored.WebShop.Persistence.SQL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDataAccess _dataAccess;

        public OrderRepository(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Order GetOrderById(int orderId)
        {
            const string sqlStatement = "SELECT * FROM [ORDER] WHERE OrderId = @OrderId";
            var order = _dataAccess.QuerySingle<Order, dynamic>(sqlStatement, new { OrderId = orderId });

            if (order.OrderId != null)
                order.OrderLineItems = GetOrderLineItemsByOrderId(order.OrderId.Value).ToList();

            return order;
        }

        public Order GetOrderByUniqueId(string uniqueId)
        {
            const string sqlStatement = "SELECT * FROM [ORDER] WHERE UniqueId = @UniqueId";
            var order = _dataAccess.QuerySingle<Order, dynamic>(sqlStatement, new { UniqueId = uniqueId });

            if (order.OrderId != null)
                order.OrderLineItems = GetOrderLineItemsByOrderId(order.OrderId.Value).ToList();

            return order;
        }

        public int CreateOrder(Order order)
        {
            var sqlStatement =
                @"INSERT INTO [dbo].[Order]
                       ([OrderPlacedOn]
                       ,[OrderReceivedOn]
                       ,[OrderFinishedOn]
                       ,[CustomerName]
                       ,[CustomerAddress]
                       ,[CustomerCity]
                       ,[CustomerStateProvince]
                       ,[CustomerCountry]
                       ,[AdminUser]
                       ,[UniqueId])
                 OUTPUT INSERTED.OrderId
                 VALUES
                       (@OrderPlacedOn
                        ,@OrderReceivedOn
                        ,@OrderFinishedOn
                        ,@CustomerName
                        ,@CustomerAddress
                        ,@CustomerCity
                        ,@CustomerStateProvince
                        ,@CustomerCountry
                        ,@AdminUser
                        ,@UniqueId)";

            var orderId = _dataAccess.QuerySingle<int, Order>(sqlStatement, order);

            sqlStatement = @"INSERT INTO [dbo].[OrderLineItem]
                           ([ProductId]
                           ,[OrderId]
                           ,[Quantity]
                           ,[Price])
                     VALUES
                           (@ProductId
                           ,@OrderId
                           ,@Quantity
                           ,@Price)";

            // create line items
            order.OrderLineItems.ForEach(item => item.OrderId = orderId);
            _dataAccess.ExecuteCommand(sqlStatement, order.OrderLineItems);

            return orderId;
        }

        public void UpdateOrder(Order order)
        {
            // update order
            var sqlStatement = @"UPDATE [Order]
                          SET [OrderPlacedOn] = @OrderPlacedOn
                          ,[OrderReceivedOn] = @OrderReceivedOn
                          ,[OrderFinishedOn] = @OrderFinishedOn
                          ,[CustomerName] = @CustomerName
                          ,[CustomerAddress] = @CustomerAddress
                          ,[CustomerCity] = @CustomerCity
                          ,[CustomerStateProvince] = @CustomerStateProvince
                          ,[CustomerCountry] = @CustomerCountry
                          ,[AdminUser] = @AdminUser
                          ,[UniqueId] = @UniqueId
                      WHERE OrderId = @OrderId";

            _dataAccess.ExecuteCommand<Order>(sqlStatement, order);

            // update line items
            sqlStatement = @"UPDATE [OrderLineItem]
                       SET [ProductId] = @ProductId
                          ,[OrderId] = @OrderId
                          ,[Quantity] = @Quantity
                          ,[Price] = @Price
                     WHERE LineItemId = @LineItemId";

            _dataAccess.ExecuteCommand<List<OrderLineItem>>(sqlStatement, order.OrderLineItems);
        }

        public IEnumerable<Order> GetOrders()
        {
            return _dataAccess.QueryList<Order, dynamic>("SELECT * FROM [ORDER]", new { });
        }

        public IEnumerable<Order> GetOrdersInProgress()
        {
            const string sqlStatement = "SELECT * FROM [ORDER] WHERE OrderFinishedOn is null";
            return _dataAccess.QueryList<Order, dynamic>(sqlStatement, new { });
        }

        public IEnumerable<Order> GetOrdersCompleted()
        {
            const string sqlStatement = "SELECT * FROM [ORDER] WHERE OrderFinishedOn is not null";
            return _dataAccess.QueryList<Order, dynamic>(sqlStatement, new { });
        }

        public IEnumerable<OrderLineItem> GetOrderLineItemsByOrderId(int orderId)
        {
            var sqlStatement = "SELECT * FROM OrderLineItem WHERE OrderId = @OrderId";
            var orderLineItems = _dataAccess.QueryList<OrderLineItem, dynamic>(sqlStatement, new { OrderId = orderId });

            sqlStatement = "SELECT * FROM Product WHERE ProductId = @ProductId";
            orderLineItems.ForEach(x => x.Product = _dataAccess.QuerySingle<Product, dynamic>(sqlStatement, new { ProductId = x.ProductId }));

            return orderLineItems;
        }
    }
}
