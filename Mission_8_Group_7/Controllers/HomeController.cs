using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mission_8_Group_7.Models;
using Mission_8_Group_7.Repositories;

namespace Mission_8_Group_7.Controllers
{
    public class HomeController : Controller
    {
        private ITaskRepository _repo;
        public HomeController(ITaskRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Quadrants()
        {
            var tasks = _repo.GetTasks();
            return View(tasks);
        }

        [HttpGet]
        public IActionResult AddEdit(int? id)
        {
            ViewBag.Categories = new SelectList(_repo.GetCategories(), "CategoryId", "CategoryName");
            if (id.HasValue)
            {
                var task = _repo.GetTaskById(id.Value);
                if (task == null) return NotFound();
                return View("AddEdit", task);
            }
            return View("AddEdit", new TaskItem());
        }

        [HttpPost]
        public IActionResult AddEdit(TaskItem variable)
        {
            if (ModelState.IsValid)
            {
                if (variable.TaskItemId == 0)
                {
                    _repo.AddTask(variable);
                }
                else
                {
                    _repo.UpdateTask(variable);
                }
                _repo.Save();
                return RedirectToAction("Quadrants");
            }
            ViewBag.Categories = new SelectList(_repo.GetCategories(), "CategoryId", "CategoryName");
            return View("AddEdit", variable);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var task = _repo.GetTaskById(id);
            if (task == null) return NotFound();
            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var task = _repo.GetTaskById(id);
            if (task != null)
            {
                _repo.DeleteTask(task);
                _repo.Save();
            }
            return RedirectToAction("Quadrants");
        }

        [HttpGet]
        public IActionResult MarkComplete(int id)
        {
            var task = _repo.GetTaskById(id);
            if (task == null) return NotFound();
            return View(task);
        }

        [HttpPost, ActionName("MarkComplete")]
        public IActionResult MarkCompleteConfirmed(int id)
        {
            var task = _repo.GetTaskById(id);
            if (task != null)
            {
                task.Completed = true;
                _repo.UpdateTask(task);
                _repo.Save();
            }
            return RedirectToAction("Quadrants");
        }
    }
}
