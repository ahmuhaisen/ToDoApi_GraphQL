namespace ToDoListQL.Models;

public class ItemData
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public bool IsDone { get; set; }
    

    public int ListId { get; set; }
    public virtual ItemList ItemList { get; set; }
}
