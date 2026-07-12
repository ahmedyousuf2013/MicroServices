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
    public class CategoryMutation
    {

        public async Task<Category> CreateCategoryAsync(Category category, [Service] ICategoryRepository categoryRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await categoryRepository.InsertAsync(category);

            await eventSender.SendAsync(nameof(Subscriptions.CategorySubscriptions.OnCreateAsync), result);

            return result;
        }
    }
}
