using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using todoApp.Context;
using todoApp.Models;

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
            List<TodoTask> taskList = new List<TodoTask>();

            taskList = _context.TodoTasks.ToList();

            return View(taskList);
        }

        public RedirectResult Create(TodoTask task)
        {
            task.Status = "In Progress";
            _context.TodoTasks.Add(task);
            _context.SaveChanges();

            return Redirect("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}