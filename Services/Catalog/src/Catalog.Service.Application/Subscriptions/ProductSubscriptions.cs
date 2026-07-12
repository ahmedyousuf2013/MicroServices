using Catalog.Service.Domain.Entities;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Service.Application.Subscriptions
{
    [ExtendObjectType(Name = "Subscription")]
    public class ProductSubscriptions
    {
        [Subscribe]
        [Topic]
        public Task<Product> OnCreateAsync([EventMessage] Product product) =>
            Task.FromResult(product);

        [Subscribe]
        [Topic]
        public Task<string> OnRemoveAsync([EventMessage] string productId) =>
            Task.FromResult(productId);
    }
}
