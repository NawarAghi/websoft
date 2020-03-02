using Assignment7.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Assignment7.Services
{
    public class Writer
    {
        

        private void Save(IEnumerable<Account> accounts)
        {
            var file = @"D:\Year3\Web Development\RE\websoft\work\s07\webapp\Assignment7\Assignment7\wwwroot\data\account.json";
            File.Delete(file);
            using (var outputStream = File.OpenWrite(file))
            {

                JsonSerializer.Serialize<IEnumerable<Account>>(
                    new Utf8JsonWriter(
                        outputStream,
                        new JsonWriterOptions
                        {
                            Indented = true
                        }
                    ),
                    accounts
                );
            }
        }

        public bool MoneyTransfer(int source, int destination, int amount)
        {
            var accounts = new Reader().GetAccounts();
            Account sourceAccount = accounts.FirstOrDefault(a => a.Number == source);
            Account destinationAccount = accounts.FirstOrDefault(a => a.Number == destination);

            if (sourceAccount != null && destinationAccount != null && sourceAccount.Balance >= amount)
            {
                sourceAccount.Balance -= amount;
                destinationAccount.Balance += amount;
                Save(accounts);
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
