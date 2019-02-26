using ApiAspnet.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace ApiAspnet.Controllers
{
    public class TodoItemController : BaseAPIController
    {
        public HttpResponseMessage Get()
        {
            return ToJson(db.TodoItem.AsEnumerable());
        }

        public HttpResponseMessage PostTodoItem([FromBody]TodoItem values)
        {
            db.TodoItem.Add(values);
            return ToJson(db.SaveChanges());
        }

        public HttpResponseMessage Put(int id, [FromBody]TodoItem values)
        {
            if (TodoItemExists(id))
                db.Entry(values).State = EntityState.Modified;
            return ToJson(db.SaveChanges());
        }

        public HttpResponseMessage Delete(int id)
        {
            if (TodoItemExists(id))
                db.TodoItem.Remove(db.TodoItem.FirstOrDefault(x => x.Id == id));
            return ToJson(db.SaveChanges());
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