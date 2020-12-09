using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Models;
using Web.Services;

namespace Web.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ILogger<ToDoController> _logger;

        private readonly ITaskService _taskService;

        public ToDoController(ILogger<ToDoController> logger, ITaskService taskService)
        {
            _logger = logger;
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _taskService.GetTasksAsync();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateToDoListItemViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateToDoListItemViewModel viewModel)
        {
            if (!ModelState.IsValid) 
            {
                return View(viewModel);
            }

            var success = await _taskService.AddTaskAsync(viewModel);

            if (success) 
            {
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
