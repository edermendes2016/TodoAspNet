using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoMVC.Models;
using TodoMVC.ViewModel;

namespace TodoMVC.Controllers
{
    public class TodoItemController : Controller
    {
        // GET: TodoItem
        public ActionResult Index()
        {
            TodoClient tc = new TodoClient();
            ViewBag.listInit = null;
            if(tc != null)
            {
                ViewBag.listTodo = tc.findAll();
            }
           

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public ActionResult Create(TodoItemViewModel tvm)
        {
            TodoClient tc = new TodoClient();
            tc.Create(tvm.todoItem);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            TodoClient tc = new TodoClient();
            tc.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            TodoClient tc = new TodoClient();
            TodoItemViewModel tvm = new TodoItemViewModel();
            tvm.todoItem = tc.find(id);
            return View("Edit", tvm);
        }
        [HttpPost]
        public ActionResult Edit(TodoItemViewModel tvm)
        {
            TodoClient tc = new TodoClient();
            tc.Edit(tvm.todoItem);
            return RedirectToAction("Index");
        }
    }
}