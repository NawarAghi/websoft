using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TransferMoney.Models;
using TransferMoney.Services;

namespace TransferMoney
{
    public class NavigationModel : PageModel
    {
        private readonly ILogger<NavigationModel> _logger;

        private JsonFileAccountService AccountService;

        public IEnumerable<Account> Accounts { get; private set; }


        public NavigationModel(ILogger<NavigationModel> logger,
             JsonFileAccountService accountService)
        {
            _logger = logger;
            AccountService = accountService;
        }

       
        public void OnGet()
        {
            Accounts = AccountService.GetAccounts();
        }
    }
}