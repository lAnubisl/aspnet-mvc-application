using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainService.DomainModels;
using FluentNHibernate.Mapping;

namespace NHibernate.Repository.Mapping
{
    public class IncomingProductMap : ClassMap<IncomingProduct>
    {
        public IncomingProductMap()
        {
            Id(x => x.Id).Column("IncomingProductId");
            Map(x => x.Count);
            References(x => x.Product).Column("ProductId");
            References(x => x.Consignment).Column("ConsignmentId");
        }
    }
}
