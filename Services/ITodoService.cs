namespace TodoExplorer.Services;

public interface ITodoService
{
    Task<dynamic> GetTodos(); 
    Task<dynamic> GetTodosByUserId(int userId);
    Task<dynamic> GetTodosByCompleted(bool IsCompleted);
}