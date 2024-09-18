using ToDoListQL.Models;

namespace ToDoListQL.GraphQL;

public class Subscription
{
    [Subscribe]
    public ItemData OnItemCreated([EventMessage] ItemData item) => item;
}
