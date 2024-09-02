using Dapper;
using DestekSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DestekSistemi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(SupportForm model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Hata"] = "Formu hatalı ya da eksik gönderdiniz!";
                return View();
            }

            var connectionString = "";

            using var connection = new SqlConnection(connectionString);

            var sql = "INSERT INTO SupportForms (Name, Email, SupportSubject, Message) VALUES (@Name, @Email, @SupportSubject, @Message)";

            var data = new
            {
                model.Name,
                model.Email,
                model.SupportSubject,
                model.Message,
            };

            var rowsAffected = connection.Execute(sql, data);

            return View("Success", model);
        }
    }
}