using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using MvcTodoList1.Models;

namespace MvcTodoList1.Controllers
{
    public class HomeController : Controller

    {

        string connectionString = @"Data Source=DESKTOP-1IBMT0C\SQLEXPRESS;Initial Catalog=NorthwindDb;User ID=sa;Password=123;Integrated Security=True";
        [HttpGet]
        public ActionResult Index()
        {
            DataTable dtbtodo = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("Select * From tblTodo", sqlCon);
                sqlda.Fill(dtbtodo);
            }

            return View(dtbtodo);

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new TodoModel());
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(TodoModel todoModel)
        {
            using (SqlConnection SqlCon = new SqlConnection(connectionString))
            {
                SqlCon.Open();
                string query = "Insert into tblTodo Values(@tName,@dtmDate,@tTim)";
                SqlCommand sqlCmd = new SqlCommand(query, SqlCon);
                sqlCmd.Parameters.AddWithValue("@tName", todoModel.tName);
                sqlCmd.Parameters.AddWithValue("@dtmDate", todoModel.dtmDate);
                sqlCmd.Parameters.AddWithValue("@tTim", todoModel.tTim);
                sqlCmd.ExecuteNonQuery();
            }


            return RedirectToAction("Index");

        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            TodoModel todoModel = new TodoModel();
            DataTable Dtbltodo = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "Select * From tblTodo where tid=@tid";
                SqlDataAdapter sqlda = new SqlDataAdapter(query, sqlCon);
                sqlda.SelectCommand.Parameters.AddWithValue("@tid", id);
                sqlda.Fill(Dtbltodo);
            }
            if (Dtbltodo.Rows.Count == 1)
            {
                todoModel.tid = Convert.ToInt32(Dtbltodo.Rows[0][0].ToString());
                todoModel.tName = Dtbltodo.Rows[0][1].ToString();
                todoModel.dtmDate = Dtbltodo.Rows[0][2].ToString();
                todoModel.tTim = Dtbltodo.Rows[0][3].ToString();

                return View(todoModel);
            }
            else
            {
                return View("Index");
            }
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(TodoModel todoModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "Update tblTodo Set tName=@tName,dtmDate=@dtmDate,tTim=@tTim Where tid=@tid";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                sqlcmd.Parameters.AddWithValue("@tid", todoModel.tid);
                sqlcmd.Parameters.AddWithValue("@tName", todoModel.tName);
                sqlcmd.Parameters.AddWithValue("@dtmDate", todoModel.dtmDate);
                sqlcmd.Parameters.AddWithValue("@tTim", todoModel.tTim);
                sqlcmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Select(int id)
        {
            TodoModel todoModel = new TodoModel();
            DataTable Dtbltodo = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "Select * From tblTodo where tid=@tid";
                SqlDataAdapter sqlda = new SqlDataAdapter(query, sqlCon);
                sqlda.SelectCommand.Parameters.AddWithValue("@tid", id);
                sqlda.Fill(Dtbltodo);
            }
            if (Dtbltodo.Rows.Count == 1)
            {
                todoModel.tid = Convert.ToInt32(Dtbltodo.Rows[0][0].ToString());
                todoModel.tName = Dtbltodo.Rows[0][1].ToString();
                todoModel.dtmDate = Dtbltodo.Rows[0][2].ToString();
                todoModel.tTim = Dtbltodo.Rows[0][3].ToString();

                return View(todoModel);
            }
            else
            {
                return View("Index");
            }
        }
        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "Delete from tblTodo Where tid=@tid";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@tid", id);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
    }
}
