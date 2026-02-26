using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission_8_Group_7.Models
{
    public class TaskItem
    {
        [Key]
        public int TaskItemId { get; set; }

        [Required(ErrorMessage = "Task item can't be empty")]
        public string Task { get; set; } = string.Empty;

        public DateTime? DueDate { get; set; }

        [Required(ErrorMessage = "Quadrant is required")]
        public int? Quadrant { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public int? CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [ValidateNever]
        public Category? Category { get; set; }

        public bool Completed { get; set; } = false;
    }
}