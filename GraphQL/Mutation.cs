using HotChocolate.Subscriptions;
using ToDoListQL.GraphQL.DataItem;
using ToDoListQL.GraphQL.List;
using ToDoListQL.Models;
using ToDoQl.Data;

namespace ToDoListQL.GraphQL;

public class Mutation
{
    [UseDbContext(typeof(AppDbContext))]
    public async Task<AddListPayload> AddListAsync(
        AddListInput input, [ScopedService] AppDbContext ctx)
    {
        var list = new ItemList 
        {
            Name = input.name
        };

        ctx.Add(list);
        await ctx.SaveChangesAsync();

        return new AddListPayload(list);
    }


    [UseDbContext(typeof(AppDbContext))]
    public async Task<AddItemPayload> AddItemAsync(AddItemInput input,
                                                   [ScopedService] AppDbContext ctx,
                                                   [Service] ITopicEventSender eventSender)
    {
        var item = new ItemData 
        {
            Title = input.title,
            Description = input.description,
            IsDone = input.isDone,
            ListId = input.listId
        };

        ctx.Add(item);
        await ctx.SaveChangesAsync();

        await eventSender.SendAsync(nameof(Subscription.OnItemCreated), item);

        return new AddItemPayload(item);
    }
}
