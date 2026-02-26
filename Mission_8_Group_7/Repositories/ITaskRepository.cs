using Mission_8_Group_7.Models;
namespace Mission_8_Group_7.Repositories
{
    public interface ITaskRepository
    {
        List<TaskItem> GetTasks();
        List<Category> GetCategories();
        TaskItem GetTaskById(int id);
        void AddTask(TaskItem task);
        void UpdateTask(TaskItem task);
        void DeleteTask(TaskItem task);
        void Save();
    }
}