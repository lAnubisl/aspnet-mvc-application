using System;
using System.Collections.Generic;
using DomainService.DomainModels;

namespace PresentationService.Models.ShoppingCard
{
    public class ShoppingCardModel
    {
        public DateTime Date { get; set; }

        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}