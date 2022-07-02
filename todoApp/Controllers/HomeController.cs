using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using todoApp.Context;
using todoApp.Models;
using todoApp.Models.ViewModel;

namespace todoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly TaskContext _context;

        public HomeController(TaskContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var todoListViewModel = GetTodoList();

            return View(todoListViewModel);

            //return View();
        }

        internal TodoViewModel GetTodoList()
        {
            List<TodoTask> taskList = new List<TodoTask>();

            taskList = _context.TodoTasks.ToList();

            return new TodoViewModel
            {
                TodoList = taskList
            };
        }

        public RedirectResult Create(TodoViewModel task)
        {
            task.TodoModel.Status = "In Progress";
            _context.TodoTasks.Add(task.TodoModel);
            _context.SaveChanges();

            return Redirect("Index");
        }

        public ActionResult Delete(int Id)
        {
            TodoViewModel task = new TodoViewModel();
            task.TodoModel = _context.TodoTasks.FirstOrDefault(t => t.Id == Id);
            _context.Entry(task.TodoModel).State = EntityState.Deleted;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            TodoViewModel task = new TodoViewModel();
            task.TodoModel = _context.TodoTasks.FirstOrDefault(t => t.Id == Id);
            if (task.TodoModel.Status == "In Progress")
            {
                task.TodoModel.Status = "Complete";
            }
            else
            {
                task.TodoModel.Status = "In Progress";
            }
            _context.Entry(task.TodoModel).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}