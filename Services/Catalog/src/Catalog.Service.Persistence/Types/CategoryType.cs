using Catalog.Service.Domain.Entities;
using HotChocolate.Types;

namespace Catalog.Service.Persistence.Types
{
    public class CategoryType : ObjectType<Category>
    {
        protected override void Configure(IObjectTypeDescriptor<Category> descriptor)
        {
            descriptor.Field(_ => _.Id);
            descriptor.Field(_ => _.Description);
        }
    }
}
