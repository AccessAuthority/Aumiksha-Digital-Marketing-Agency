using Aumiksha.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aumiksha.Controllers
{
    public class HomeController : Controller
    {
        public AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult index()
        {
            var data = _context.form_T.ToList();
            return View(data);
        }
        public IActionResult AdminLogin()
        {
            // Check if the user is already logged in
            
            return View();
        }
        [HttpPost]
        public IActionResult AdminLogin(string username, string password)
        {
            var data = _context.AdminTable.FirstOrDefault(s => s.username == username && s.password == password);
            if (data != null)
            {
                HttpContext.Session.SetString("user", username);
                return RedirectToAction("AdminPanel");
            }
            else
            {
                TempData["msg"] = "Username or Password is incorrect";
                return RedirectToAction("AdminLogin");
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("AdminLogin");
        }
        public IActionResult AdminPanel()
        {
            // Check if the user is logged in
            if (HttpContext.Session.GetString("user") == null)
            {
                return RedirectToAction("AdminLogin");
            }
            var data = _context.form_T.ToList();
            return View(data);
        }
        [HttpPost]
        public IActionResult index( form_T t)
        {
            _context.form_T.Add(t);
            _context.SaveChanges();
            return RedirectToAction("index");

        }
        //Delete data from Admin Panel
        public IActionResult Delete(int id)
        {
            var data = _context.form_T.Find(id);
            _context.form_T.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("AdminPanel");
        }
    }
}
