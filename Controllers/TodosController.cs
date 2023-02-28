using AspNetTodoWebApi.Models;
using AspNetTodoWebApi.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TodosController : ControllerBase
{
  public TodosController()
  {
  }

  [HttpGet]
  public ActionResult<List<Todo>> GetAll()
  {
    return TodoService.GetAll();
  }

  [HttpGet("{id}")]
  public ActionResult<Todo> Get(int id)
  {
    Todo? todo = TodoService.Get(id);
    return todo is null ? NotFound() : todo;
  }

  [HttpPost]
  public ActionResult Create(Todo newTodo)
  {
    TodoService.Add(newTodo);
    return CreatedAtAction(nameof(Get), new { description = newTodo.Description }, newTodo);
  }

  [HttpDelete("{id}")]
  public ActionResult Delete(int id)
  {
    TodoService.Delete(id);

    return NoContent();
  }

  [HttpPut]
  public ActionResult Update(Todo updatedTodo)
  {
    TodoService.Update(updatedTodo);
    return NoContent();
  }
}