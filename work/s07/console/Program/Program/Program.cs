using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Program
{
    class Program
    {


        static void Main(String[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            var accounts = ReadAccounts();

            Console.WriteLine("----------------------------");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) View accounts");
            Console.WriteLine("2) View account by ID");
            Console.WriteLine("3) Search");
            Console.WriteLine("4) Move");
            Console.WriteLine("5) Create new account");
            Console.WriteLine("6) EXIT");
            Console.WriteLine("----------------------------");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    viewAccounts(accounts);
                    return true;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Please enter the ID: ");
                    string id = Console.ReadLine();
                    while (!isDigit(id))
                    {
                        Console.WriteLine("Please enter only numbers:  ");
                        id = Console.ReadLine();
                    }
                    viewAccounts(accounts, Convert.ToInt32(id));
                    return true;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Please enter the search word: ");
                    search(accounts, Console.ReadLine());
                    return true;
                case "4":
                    Console.Clear();
                    Console.WriteLine("Please enter SOURCE number: ");
                    string from = Console.ReadLine();
                    while (!isDigit(from))
                    {
                        Console.WriteLine("Please enter only numbers:  ");
                        from = Console.ReadLine();
                    }

                    Console.WriteLine("Please enter DESTINATION number: ");
                    string to = Console.ReadLine();
                    while (!isDigit(to))
                    {
                        Console.WriteLine("Please enter only numbers:  ");
                        to = Console.ReadLine();
                    }
                    move(accounts, Convert.ToInt32(from), Convert.ToInt32(to));
                    return true;
                case "5":
                    Console.WriteLine("Please enter a number:  ");
                    string number = Console.ReadLine();
                    while (!isDigit(number))
                    {
                        Console.WriteLine("Please enter only numbers:  ");
                        number = Console.ReadLine();
                    }
                    int numb = Convert.ToInt32(number);

                    Console.WriteLine("Please enter a balance:  ");
                    string bal = Console.ReadLine();
                    while (!isDigit(bal))
                    {
                        Console.WriteLine("Please enter only numbers:  ");
                        bal = Console.ReadLine();
                    }
                    int balance = Convert.ToInt32(bal);
                    Console.WriteLine("Please enter a label:  ");
                    string label = Console.ReadLine();
                    while (!isLetter(label))
                    {
                        Console.WriteLine("Please enter only letters:  ");
                        label = Console.ReadLine();
                    }
                    Console.WriteLine("Please enter an owner:  ");
                    string own = Console.ReadLine();
                    while (!isDigit(own))
                    {
                        Console.WriteLine("Please enter only numbers:  ");
                        own = Console.ReadLine();
                    }
                    int owner = Convert.ToInt32(own);
                    createAccount(accounts, numb, balance, label, owner);
                    return true;
                case "6":
                    Console.Clear();
                    Console.WriteLine("Bye Bye ! ");
                    return false;
                default:
                    Console.Clear();
                    Console.WriteLine("Please Choose a valid number!");
                    return true;
            }
        }

        static IEnumerable<Account> ReadAccounts()
        {
            String file = "../../../../../../../data/account.json";

            using (StreamReader r = new StreamReader(file))
            {
                string data = r.ReadToEnd();


                var json = JsonSerializer.Deserialize<Account[]>(
                    data,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }
                );

                return json;
            }
        }

        static void search(IEnumerable<Account> accounts, string word)
        {
            var isNumeric = int.TryParse(word, out int n);

            Console.WriteLine("+---------+---------+---------+---------+");
            Console.WriteLine("|  Number | Balance |  Label  |  Owner  |");
            Console.WriteLine("+---------+---------+---------+---------+");


            foreach (var account in accounts)
            {
                if (isNumeric)
                {
                    var number = account.Number.ToString();
                    var owner = account.Owner.ToString();
                    if (number.Contains(n.ToString()) || owner.Contains(n.ToString()))
                    {
                        Console.Write('|');
                        Console.Write("{0,9}", account.Number); Console.Write('|');
                        Console.Write("{0,9}", account.Balance); Console.Write('|');
                        Console.Write("{0,9}", account.Label); Console.Write('|');
                        Console.Write("{0,9}", account.Owner); Console.Write("|\n");
                        Console.WriteLine("+---------+---------+---------+---------+");
                    }

                }
                else
                {
                    if (account.Label.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        Console.Write('|');
                        Console.Write("{0,9}", account.Number); Console.Write('|');
                        Console.Write("{0,9}", account.Balance); Console.Write('|');
                        Console.Write("{0,9}", account.Label); Console.Write('|');
                        Console.Write("{0,9}", account.Owner); Console.Write("|\n");
                        Console.WriteLine("+---------+---------+---------+---------+");
                    }

                }
            }


        }

        static void viewAccounts(IEnumerable<Account> accounts, int number = 0)
        {


            Console.WriteLine("+---------+---------+---------+---------+");
            Console.WriteLine("|  Number | Balance |  Label  |  Owner  |");
            Console.WriteLine("+---------+---------+---------+---------+");

            if (number > 0)
            {
                foreach (var account in accounts)
                {
                    if (number == account.Number)
                    {
                        Console.Write('|');
                        Console.Write("{0,9}", account.Number); Console.Write('|');
                        Console.Write("{0,9}", account.Balance); Console.Write('|');
                        Console.Write("{0,9}", account.Label); Console.Write('|');
                        Console.Write("{0,9}", account.Owner); Console.Write("|\n");
                        Console.WriteLine("+---------+---------+---------+---------+");
                    }
                }
            }
            else
            {
                foreach (var account in accounts)
                {
                    Console.Write('|');
                    Console.Write("{0,9}", account.Number); Console.Write('|');
                    Console.Write("{0,9}", account.Balance); Console.Write('|');
                    Console.Write("{0,9}", account.Label); Console.Write('|');
                    Console.Write("{0,9}", account.Owner); Console.Write("|\n");
                    Console.WriteLine("+---------+---------+---------+---------+");
                }
            }

        }

        static void move(IEnumerable<Account> accounts, int from, int to)
        {
            foreach (var fromAccount in accounts)
            {
                foreach (var toAccount in accounts)
                {
                    if (from == fromAccount.Number && to == toAccount.Number)
                    {
                        toAccount.Balance += fromAccount.Balance;
                        fromAccount.Balance = 0;
                        break;
                    }
                }
            }

            saveAccounts(accounts);
        }

        static void saveAccounts(IEnumerable<Account> accounts)
        {
            String file = "../../../../../../../data/account.json";
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

        static void createAccount(IEnumerable<Account> accounts, int number,
             int balance, string label, int owner)
        {
            var ac = new Account(number, balance, label, owner);
            IEnumerable<Account> acc = accounts.Append(ac);

            saveAccounts(acc);

        }

        static bool isDigit(string word)
        {

            if (Regex.IsMatch(word, @"^\d+$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool isLetter(string word)
        {
            if (Regex.IsMatch(word, @"^[a-zA-Z]+$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    public class Account
    {
        public int Number { get; set; }
        public int Balance { get; set; }
        public string Label { get; set; }
        public int Owner { get; set; }

        public Account(int number, int balance, string label, int owner)
        {
            this.Number = number;
            this.Balance = balance;
            this.Label = label;
            this.Owner = owner;
        }
        public Account() { }
        public override string ToString()
        {
            return JsonSerializer.Serialize<Account>(this);
        }
    }
}
