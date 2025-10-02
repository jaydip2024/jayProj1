using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MvcTodoList1.Models
{
	public class TodoModel
	{
        [Key]
        public int tid { get; set; }
        [DisplayName("Name:")]
        public string tName { get; set; }
        [DisplayName("Date:")]
        public string dtmDate { get; set; }
        [DisplayName("Time:")]
        public string tTim { get; set; }
        
    }
}