using ToDoListQL.Models;
using ToDoQl.Data;

namespace ToDoListQL.GraphQL.List;

public class ListType : ObjectType<ItemList>
{
    protected override void Configure(IObjectTypeDescriptor<ItemList> descriptor)
    {
        descriptor.Description("Represents a List of items.");

        descriptor
            .Field(l => l.ItemDatas)
            //.ResolveWith<Resolvers>(x => x.GetItems(default!, default!))
            .UseDbContext<AppDbContext>()
            .Description("The items in the list.");
    }

    private class Resolvers
    {
        public IQueryable<ItemData> GetItems(
            ItemList list, [ScopedService] AppDbContext ctx)
        {
            return ctx.Items.Where(i => i.ListId == list.Id);
        }
    }
}
