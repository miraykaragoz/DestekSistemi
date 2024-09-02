using Dapper;
using DestekSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DestekSistemi.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            var connectionString = "";

            using var connection = new SqlConnection(connectionString);

            var sql = "SELECT * FROM SupportForms";

            var forms = connection.Query<SupportForm>(sql).ToList();

            return View(forms);
        }

        public IActionResult Delete(int id)
        {
            var connectionString = "";

            using var connection = new SqlConnection(connectionString);

            var sql = "DELETE FROM SupportForms WHERE Id = " + id;

            var rowsAffected = connection.Execute(sql, new { Id = id });

            ViewBag.MessageCssClass = "alert-success";
            ViewBag.Message = "Destek formu silme işlemi başarıyla gerçekleşti.";
            return View("Message");
        }
        
        public IActionResult Approve(int id)
        {
            var connectionString = "";

            using var connection = new SqlConnection(connectionString);

            var sql = "DELETE FROM SupportForms WHERE Id = " + id;

            var rowsAffected = connection.Execute(sql, new { Id = id });

            ViewBag.MessageCssClass = "alert-success";
            ViewBag.Message = "Destek formu onaylama işlemi başarıyla gerçekleşti.";
            return View("Message");
        }
    }
}