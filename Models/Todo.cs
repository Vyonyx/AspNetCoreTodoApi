namespace AspNetTodoWebApi.Models;

public class Todo
{
  public int Id { get; set; }
  public string? Description { get; set; }
  public string? Category { get; set; }
  public bool IsComplete = false;
}