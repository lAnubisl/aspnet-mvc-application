using System;
using System.Collections.Generic;
using System.Linq;
using DomainService.DomainModels;
using DomainService.DomainServiceInterfaces;
using DomainService.Enumerations;
using DomainService.RepositoryInterfaces;

namespace DomainService.DomainServices
{
    public class OrderDomainService : GenericDomainService<Order, IGenericRepository<Order>>, IOrderDomainService
    {
        #region IOrderDomainService Members

        public IList<Order> Load(long userId, OrderStatus status)
        {
            return Repository.Query().Where(o => o.Customer.Id == userId && o.Status == status).ToList();
        }

        public IList<Order> LoadByDateRange(DateTime startDate, DateTime endDate)
        {
            return Repository.Query().Where(o => o.CreationDate <= endDate && o.CreationDate >= startDate).ToList();
        }

        #endregion
    }
}