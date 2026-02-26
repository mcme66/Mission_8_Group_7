using Microsoft.EntityFrameworkCore;
using Mission_8_Group_7.Data;
using Mission_8_Group_7.Models;

namespace Mission_8_Group_7.Repositories
{
    public class EFTaskRepository : ITaskRepository
    {
        private TaskContext _context;

        public EFTaskRepository(TaskContext context)
        {
            _context = context;
        }

        public List<TaskItem> GetTasks()
        {
            return _context.Tasks
                .Include(t => t.Category)
                .Where(t => t.Completed == false)
                .ToList();
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public TaskItem GetTaskById(int id)
        {
            return _context.Tasks
                .Include(t => t.Category)
                .FirstOrDefault(t => t.TaskItemId == id);
        }

        public void AddTask(TaskItem task)
        {
            _context.Tasks.Add(task);
        }

        public void UpdateTask(TaskItem task)
        {
            _context.Tasks.Update(task);
        }

        public void DeleteTask(TaskItem task)
        {
            _context.Tasks.Remove(task);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
