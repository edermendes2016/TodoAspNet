using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoMVC.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public bool Ativo { get; set; }
        public DateTime Data { get; set; }
    }
}