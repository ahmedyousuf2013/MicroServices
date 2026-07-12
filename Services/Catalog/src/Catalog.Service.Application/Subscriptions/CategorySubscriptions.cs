using Catalog.Service.Domain.Entities;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Service.Application.Subscriptions
{

    [ExtendObjectType(Name = "Subscription")]
    public class CategorySubscriptions
    {

        [Subscribe]
        [Topic]
        public Task<Category> OnCreateAsync([EventMessage] Category category) =>
            Task.FromResult(category);
    }
}
