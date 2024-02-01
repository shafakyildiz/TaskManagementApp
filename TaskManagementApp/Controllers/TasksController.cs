using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TaskManagementApp.Models;
using Task = TaskManagementApp.Models.Task;

namespace TaskManagementApp.Controllers
{
    public class TasksController : Controller
    {
        private static List<Task> tasks = new List<Task>();

        public IActionResult Index()
        {
            return View(tasks);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Task task)
        {
            task.Id = tasks.Count + 1;
            tasks.Add(task);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var task = tasks.Find(t => t.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        public IActionResult Edit(int id)
        {
            var task = tasks.Find(t => t.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(Task updatedTask)
        {
            var index = tasks.FindIndex(t => t.Id == updatedTask.Id);

            if (index == -1)
            {
                return NotFound();
            }

            tasks[index] = updatedTask;

            return RedirectToAction("Index");
        }
    }
}