using Catalog.Service.Domain.Entities;
using Catalog.Service.Domain.Repositories;
using HotChocolate;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Service.Application.Mutations
{
    [ExtendObjectType(Name = "Mutation")]
    public class ProductMutation
    {
        public async Task<Product> CreateProductAsync(Product product, [Service] IProductRepository productRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await productRepository.InsertAsync(product);

            await eventSender.SendAsync(nameof(Subscriptions.ProductSubscriptions.OnCreateAsync), result);

            return result;
        }

        public async Task<bool> RemoveProductAsync(string id, [Service] IProductRepository productRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await productRepository.RemoveAsync(id);

            if (result)
            {
                await eventSender.SendAsync(nameof(Subscriptions.ProductSubscriptions.OnRemoveAsync), id);
            }

            return result;
        }

    }
}
