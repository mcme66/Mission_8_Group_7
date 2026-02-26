using Microsoft.EntityFrameworkCore;
using Mission_8_Group_7.Models;
using System.Reflection.Emit;

namespace Mission_8_Group_7.Data
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options)
            : base(options)
        {
        }

        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Home" },
                new Category { CategoryId = 2, CategoryName = "School" },
                new Category { CategoryId = 3, CategoryName = "Work" },
                new Category { CategoryId = 4, CategoryName = "Church" }
            );

            modelBuilder.Entity<TaskItem>().HasData(
                // Quadrant 1: Important / Urgent
                new TaskItem { TaskItemId = 1, Task = "Finish project presentation", DueDate = new DateTime(2025, 3, 1), Quadrant = 1, CategoryId = 1, Completed = false },
                new TaskItem { TaskItemId = 2, Task = "Study for exam tomorrow", DueDate = new DateTime(2025, 3, 2), Quadrant = 1, CategoryId = 3, Completed = false },

                // Quadrant 2: Important / Not Urgent
                new TaskItem { TaskItemId = 3, Task = "Plan weekly workout schedule", DueDate = new DateTime(2025, 3, 15), Quadrant = 2, CategoryId = 4, Completed = false },
                new TaskItem { TaskItemId = 4, Task = "Read personal development book", DueDate = new DateTime(2025, 3, 20), Quadrant = 2, CategoryId = 2, Completed = false },

                // Quadrant 3: Not Important / Urgent
                new TaskItem { TaskItemId = 5, Task = "Reply to non-critical work emails", DueDate = new DateTime(2025, 3, 3), Quadrant = 3, CategoryId = 1, Completed = false },
                new TaskItem { TaskItemId = 6, Task = "Schedule dentist appointment", DueDate = new DateTime(2025, 3, 4), Quadrant = 3, CategoryId = 4, Completed = false },

                // Quadrant 4: Not Important / Not Urgent
                new TaskItem { TaskItemId = 7, Task = "Reorganize old photo albums", DueDate = new DateTime(2025, 4, 1), Quadrant = 4, CategoryId = 2, Completed = false }
            );
        }
    }
}