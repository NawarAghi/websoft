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
    public class Reader
    {
        

        public IEnumerable<Account> GetAccounts()
        {
            var file = @"D:\Year3\Web Development\RE\websoft\work\s07\webapp\Assignment7\Assignment7\wwwroot\data\account.json";
            using (var jsonFileReader = File.OpenText(file))
            {
                return JsonSerializer.Deserialize<Account[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
    }
}
