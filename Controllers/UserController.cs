using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using UsersApp.Models;

namespace UsersApp.Controllers
{
    public class UserController : Controller
    {
        private readonly ConnectionStrings connectionStrings;

        public UserController(ConnectionStrings connectionStrings)
        {
            this.connectionStrings = connectionStrings;
        }
        // GET: User
        public ActionResult Index()
        {
            using (var conn = new MySqlConnection(connectionStrings.MySQL))
            {
                var sql = @"SELECT id,firstname,lastname,email,location from user";

                var s = conn.Query<User>(sql);
                return View(s);
            }
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            using (var conn = new MySqlConnection(connectionStrings.MySQL))
            {
                var sql = @"SELECT id,firstname,lastname,email,location from user where id=@id";

                var s = conn.Query<User>(sql, new { id }).SingleOrDefault();
                return View(s);
            }
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionStrings.MySQL))
                {
                    var sql = @"INSERT INTO user(email,firstname,lastname,location) values(@email,@firstname,@lastname,@location)";

                    var s = conn.Execute(sql,new { email = user.Email, firstname=user.FirstName, lastname=user.LastName, location = user.Location});
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Create");
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            using (var conn = new MySqlConnection(connectionStrings.MySQL))
            {
                var sql = @"SELECT id,firstname,lastname,email,location from user where id=@id";

                var s = conn.Query<User>(sql,new { id}).SingleOrDefault();
                return View(s);
            }
            
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionStrings.MySQL))
                {
                    var sql = @"Update user SET email=@email,firstname=@firstname,lastname=@lastname,location=@location Where id=@id";

                    var s = conn.Execute(sql, new { email = user.Email, firstname = user.FirstName, lastname= user.LastName, location = user.Location, id });
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            using (var conn = new MySqlConnection(connectionStrings.MySQL))
            {
                var sql = @"SELECT id,firstname,lastname,email,location from user where id=@id";

                var s = conn.Query<User>(sql, new { id }).SingleOrDefault();
                return View(s);
            }
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, User user)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionStrings.MySQL))
                {
                    var sql = @"DELETE FROM user WHERE id=@id";

                    var s = conn.Execute(sql, new { id });
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}