using System;
using System.Collections.Generic;
using System.Linq;
using DomainService.DomainModels;
using DomainService.DomainServiceInterfaces;
using DomainService.Enumerations;
using PresentationService.Interfaces;
using PresentationService.Models.ShoppingCard;

namespace PresentationService.Services
{
    public class OrderPresentationService : IOrderPresentationService
    {
        private readonly IOrderDomainService orderDomainService;
        private readonly IProductDomainService productDomainService;

        public OrderPresentationService(IOrderDomainService orderDomainService, IProductDomainService productDomainService)
        {
            this.orderDomainService = orderDomainService;
            this.productDomainService = productDomainService;
        }

        #region IOrderPresentationService Members

        public void PayOrder(long userId)
        {
            IList<Order> paidOrders = orderDomainService.Load(userId, OrderStatus.Pending);
            if (paidOrders.Any())
            {
                Order paidOrder = paidOrders.First();
                paidOrder.Status = OrderStatus.Paid;
                orderDomainService.Save(paidOrder);
            }
        }

        public void CompleteOrder(long userId)
        {
            IList<Order> pendingOrders = orderDomainService.Load(userId, OrderStatus.Pending);
            if (pendingOrders.Any())
            {
                Order pendingOrder = pendingOrders.First();
                pendingOrder.Status = OrderStatus.Completed;
                orderDomainService.Save(pendingOrder);
            }
        }

        public ShoppingCardModel LoadShoppingCard(long userId)
        {
            var model = new ShoppingCardModel();
            ////Order pendingOrder = LoadPendingOrderOrCreateNewOne(userId);
            ////Mapper.Map(pendingOrder, model);
            return model;
        }

        public void AddProductToShoppingCard(long productId, long userId)
        {
            Product product = productDomainService.Load(productId);
            if (product != null)
            {
                Order pendingOrder = LoadPendingOrderOrCreateNewOne(userId);
                pendingOrder.AddOrderItem(new OrderItem { Product = product, Price = product.Price });
                pendingOrder.CreationDate = DateTime.Now;
                orderDomainService.Save(pendingOrder);
            }
        }

        #endregion

        private Order LoadPendingOrderOrCreateNewOne(long userId)
        {
            IList<Order> pendingOrders = orderDomainService.Load(userId, OrderStatus.Pending);
            return pendingOrders.Any()
                       ? pendingOrders.First()
                       : new Order
                             {
                                 Status = OrderStatus.Pending,
                                 Customer = new User { Id = userId }
                             };
        }
    }
}