using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace TransferMoney.Models
{
    public class Account
    {
        public int Number { get; set; }
        public int Balance { get; set; }
        public string Label { get; set; }
        public int Owner { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Account>(this);
    }
}
