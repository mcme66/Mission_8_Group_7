using Mission_8_Group_7.Models;
using System.ComponentModel.DataAnnotations;

namespace Mission_8_Group_7.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public List<TaskItem> Tasks { get; set; }
    }
}