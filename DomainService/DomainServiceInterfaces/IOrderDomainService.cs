using System;
using System.Collections.Generic;
using DomainService.DomainModels;
using DomainService.Enumerations;

namespace DomainService.DomainServiceInterfaces
{
    public interface IOrderDomainService : IGenericDomainService<Order>
    {
        IList<Order> Load(long userId, OrderStatus status);

        IList<Order> LoadByDateRange(DateTime startDate, DateTime endDate);
    }
}