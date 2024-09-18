using ToDoListQL.Models;
using ToDoQl.Data;

namespace ToDoListQL.GraphQL;

public class Query
{
    [UseDbContext(typeof(AppDbContext))]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<ItemList> GetList([ScopedService] AppDbContext ctx)
    {
        return ctx.Lists;
    }

    [UseDbContext(typeof(AppDbContext))]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<ItemData> GetItems([ScopedService] AppDbContext ctx)
    {
        return ctx.Items;
    }
}
