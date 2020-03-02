using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Assignment7.Controllers
{
    public class AccountController : Controller
    {

        [HttpGet("/api/accounts")]
        public IActionResult Index()
        {
            var reader = new Assignment7.Services.Reader().GetAccounts();

            return Json(reader);
        }

        [HttpGet("api/accounts/{id?}")]
        public IActionResult Account(int id)
        {
            try
            {
                var account = new Assignment7.Services.Reader().GetAccounts().First(x => x.Number == id);
                return Json(account);
            }
            catch(Exception e)
            {
                return Json("This account does not exist");
            }
        }

        [HttpPost("navigate/{direction?}")]
        [HttpGet("navigate/{*any}")]
        public IActionResult Navigate(int direction = 0)
        {
            if (direction < 0)
            {
                Response.Redirect("0");
                direction = 0;
            }

            if (direction >= new Assignment7.Services.Reader().GetAccounts().Count())
                direction = new  Assignment7.Services.Reader().GetAccounts().Count() - 1;

            ViewData["direction"] = direction;

            return View();
        }



    }
}