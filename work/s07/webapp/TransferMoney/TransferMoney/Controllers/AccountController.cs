using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TransferMoney.Models;
using TransferMoney.Services;


namespace TransferMoney.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountController : Controller
    {
        public AccountController(JsonFileAccountService accountService)
        {
            this.AccountService = accountService;
        }

        public JsonFileAccountService AccountService { get; }

        [HttpGet]
        public IEnumerable<Account> Get()
        {
            return this.AccountService.GetAccounts();
        }

        
        [HttpGet("/api/accounts/{number}")]
        public ActionResult GetId(int number)
        {
            try
            {
                var res = this.AccountService.GetAccounts().First(x => x.Number == number);
                if (res != null)
                {
                    return Json(this.AccountService.GetAccounts().First(x => x.Number == number));
                }
                else
                {
                    return Json("This account does not exist");
                }
            }
            catch(InvalidOperationException e)
            {
                return Json("This account does not exist");
            }
            

        }

    }
}