using AspNetTodoWebApi.Models;

namespace AspNetTodoWebApi.Services;

public static class TodoService
{
  public static List<Todo> TodosList { get; }
  public static int nextId = 4;

  static TodoService()
  {
    TodosList = new List<Todo>()
    {
      new Todo { Id = 1, Description = "Take out the trash.", Category = "Chores"},
      new Todo { Id = 2, Description = "Empty the dishwasher.", Category = "Chores" },
      new Todo { Id = 3, Description = "Pay the internet bill", Category = "Finances" }
    };
  }

  public static List<Todo> GetAll() => TodosList;

  public static Todo? Get(int id) => TodosList.FirstOrDefault(t => t.Id == id);

  public static void Add(Todo newTodo) => TodosList.Add(newTodo);

  public static void Delete(int id)
  {
    Todo? existingTodo = Get(id);

    if (existingTodo is null)
      return;
    
    TodosList.Remove(existingTodo);
  }

  public static void Update(Todo updatedTodo)
  {
    int index = TodosList.FindIndex(t => t.Id == updatedTodo.Id);

    if (index == -1)
      return;
    
    TodosList[index] = updatedTodo;
  }
}