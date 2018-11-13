using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ApiAspnet.Models;

namespace ApiAspnet.Controllers
{
    public class TodoItemController : System.Web.Http.ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/TodoItem
        public IQueryable<TodoItem> GetTodoItem()
        {
            return db.TodoItem;
        }

        // GET: api/TodoItem/5
        [ResponseType(typeof(TodoItem))]
        public IHttpActionResult GetTodoItem(int id)
        {
            TodoItem todoItem = db.TodoItem.Find(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            return Ok(todoItem);
        }

        // PUT: api/TodoItem/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTodoItem(int id, TodoItem todoItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            db.Entry(todoItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TodoItem
        [ResponseType(typeof(TodoItem))]
        public IHttpActionResult PostTodoItem(TodoItem todoItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else if(todoItem.Data.ToString() == "01/01/0001 00:00:00")
            {
                todoItem.Data = DateTime.Now;
                db.TodoItem.Add(todoItem);
                db.SaveChanges();
            }
            else
            {
                db.TodoItem.Add(todoItem);
                db.SaveChanges();
            }

            return CreatedAtRoute("DefaultApi", new { id = todoItem.Id }, todoItem);

        }

        // DELETE: api/TodoItem/5
        [ResponseType(typeof(TodoItem))]
        public IHttpActionResult DeleteTodoItem(int id)
        {
            TodoItem todoItem = db.TodoItem.Find(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            db.TodoItem.Remove(todoItem);
            db.SaveChanges();

            return Ok(todoItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TodoItemExists(int id)
        {
            return db.TodoItem.Count(e => e.Id == id) > 0;
        }
    }
}