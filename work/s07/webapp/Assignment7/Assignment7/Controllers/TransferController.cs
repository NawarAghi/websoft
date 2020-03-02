using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Assignment7.Controllers
{
    public class TransferController : Controller
    {
        private readonly ILogger<TransferController> _logger;

        public TransferController(ILogger<TransferController> logger)
        {
            _logger = logger;
        }

        public IActionResult Transfer(IFormCollection collection)
        {
            if (!string.IsNullOrEmpty(collection["amount"]))
            {
                if (new Assignment7.Services.Writer().MoneyTransfer(Convert.ToInt32(collection["source"]),
                    Convert.ToInt32(collection["destination"]), Convert.ToInt32(collection["amount"])))
                {
                    return Ok("Transaction has completed successfully");
                    
                }
                else
                {
                    return NotFound("Transaction Failed! Check Your information and balance");
                }
            }

            return View();
        }

        [HttpPut("api/accounts/{from?}/{to?}/{balance?}")]
        public IActionResult MoveMoney(int from, int to, int balance)
        {
            if (new Assignment7.Services.Writer().MoneyTransfer(from, to, balance))
            {
                return Ok("Transaction has completed successfully");

            }
            else
            {
                return NotFound("Transaction Failed! Check Your information and balance");
            }

        }
    }
}