using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;

namespace BankAccountManagement;

class Program
{
    static void Main()
    {
        new Bank("StartUpPage");
    }
}
abstract class AccountAuthenication
{
    protected abstract void Login();
    protected abstract void ForgotPassword();
    protected abstract void CreateAccount();
}
public abstract class BankServices
{
    public abstract void StartUp();
}
class Account
{
    public string account_name { get; set; }
    public long account_number { get; set; }
    public long account_password { get; set; }
    public long account_balance { get; set; } = 0;
}
class TransactionHistory
{
    public string TransactionType { get; set; }
    public string account_name { get; set; }

    public List<Account> transaction { get; set; } = new List<Account>();
}
class AccountManager : AccountAuthenication
{
    public AccountManager(int choose)
    {

        switch (choose)
        {
            case 1:
                Console.Clear();
                Login();
                break;
            case 2:
                Console.Clear();
                ForgotPassword();
                break;
            case 3:
                CreateAccount();
                Console.Clear();
                break;

        }
    }

    protected override void Login()
    {
        int attempt = 0;
        Console.FontSize = 15;
        int accountNumber, accountPassword = 0;

        do
        {
            Console.WriteLine("Login\n");
            Console.WriteLine("Type '0' to Back.\n");
            while (true)
            {
                Console.Write("Enter Account number:");

                if (int.TryParse(Console.ReadLine(), out accountNumber))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input.Please enter a valid account number");
                    Thread.Sleep(500);
                    Console.Clear();
                    Login();
                }
            }

            if (accountNumber == 0)
            {
                Console.Clear();
                new Bank("StartUpPage");
            }
            else
            {
                while (true)
                {
                    Console.Write("Enter Account Password:");

                    if (int.TryParse(Console.ReadLine(), out int account_Password))
                    {
                        accountPassword = account_Password;
                        if (account_Password == 0)
                        {
                            Console.Clear();
                            new Bank("StartUpPage");
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.Please enter valid account password.");
                        Thread.Sleep(500);
                        Console.Clear();
                        Login();
                    }

                }

            }

            var isAccountExist = Bank.accountlist.Where(x => x.account_number == accountNumber && x.account_password == accountPassword);

            if (isAccountExist.Any())
            {
                var Account = Bank.accountlist.Find(x => x.account_number == accountNumber);
                Console.WriteLine("Login Successfully.");
                Thread.Sleep(500);
                Console.Clear();
                new Bank("HomePage", Account.account_name);
            }
            else if (attempt == 3)
            {
                Console.Write("Attempt exceeded...exiting program.");
                Thread.Sleep(500);
                Environment.Exit(0);
            }
            else
            {
                attempt++;
                Console.WriteLine($"Login failed!!attempt({attempt}/3)");
                Thread.Sleep(500);
                Console.Clear();
            }

        } while (attempt < 3);
    }
    protected override void ForgotPassword()
    {
        Console.FontSize = 13;
        while (true)
        {
            Console.WriteLine("Forgot Password\n");
            Console.WriteLine("Type '0' to Back.\n");
            Console.Write("Enter Account number:");
            int accountNumber = int.Parse(Console.ReadLine());
            var findAccountNumber = Bank.accountlist.Where(x => x.account_number == accountNumber);


            if (findAccountNumber.Any())
            {
                Console.Write("Enter new account password:");
                int password = int.Parse(Console.ReadLine());

                var changeAccountPassword = Bank.accountlist.Find(x => x.account_number == accountNumber);
                changeAccountPassword.account_password = password;

                var isPasswordChangeSuccesfully = Bank.accountlist.Where(x => x.account_password == password);

                if (isPasswordChangeSuccesfully.Any())
                {
                    Console.WriteLine("Account Password Change successfully.");
                    Thread.Sleep(500);
                    Console.Clear();
                    new Bank("StartUpPage");

                }
                else
                {
                    Console.Write("Please Try again later.");
                }
            }
            else
            {
                Console.Write("Account number doesn't exist.");
                Console.Clear();
            }
        }

    }
    protected override void CreateAccount()
    {

        Console.Clear();
        string newAccountName = "";
        int newAccountNumber, newAccountPassword, newAccountBalance = 0;

        Console.WriteLine("""
        Create Account
        
        Type '0' to back.
        
        """);

        while (true)
        {
            Console.Write("Enter a new account name(8 - 16 Character):");
            newAccountName = Console.ReadLine();


            if (newAccountName == "0")
            {
                Console.Clear();
                new Bank("StartUpPage");
            }
            if (newAccountName.Length >= 8 && newAccountName.Length <= 16)
            {
                if (newAccountName.Any(Char.IsDigit))
                {
                    Console.WriteLine("Account name doesn't contain digit.");
                    Thread.Sleep(500);
                }
                else
                    break;
            }
            else
            {
                Console.WriteLine("Account number must be 8 - 16 digit.");
            }


        }
        Console.WriteLine();

        while (true)
        {
            Console.Write("Enter a new account number(8 - 16 digit):");
            if (int.TryParse(Console.ReadLine(), out newAccountNumber))
            {
                if (newAccountNumber == 0)
                {
                    Console.Clear();
                    new Bank("StartUpPage");
                }
                if (newAccountNumber.ToString().Length >= 8 && newAccountNumber.ToString().Length <= 16)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Account number must be 8 - 16 digit.");
                }
            }
            else
                Console.WriteLine("Please input valid account number.");
        }
        Console.WriteLine();

        while (true)
        {
            Console.Write("Enter a new account password(8 - 16 digit):");
            if (int.TryParse(Console.ReadLine(), out newAccountPassword))
            {
                if (newAccountPassword == 0)
                {
                    Console.Clear();
                    new Bank("StartUpPage");
                }
                if (newAccountPassword.ToString().Length >= 8 && newAccountPassword.ToString().Length <= 16)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Account number must be 8 - 16 digit.");
                }
            }
            else
                Console.WriteLine("Please input valid account number.");
        }
        Console.WriteLine();


        Bank.accountlist.Add(
            new Account()
            {
                account_name = newAccountName,
                account_number = newAccountNumber,
                account_password = newAccountPassword,
            }
        );
        var isAccountAdded = Bank.accountlist.Where(a => a.account_name == newAccountName && a.account_number == newAccountNumber && a.account_balance == newAccountBalance && a.account_password == newAccountPassword);

        if (isAccountAdded.Any())
        {
            Console.Write("Added Account Successfully.");
            Thread.Sleep(500);
            Console.Clear();
            new Bank("StartUpPage");

        }
        else
            Console.Write("Added Account Unsuccesfully.");
    }
}
class Bank : BankServices
{
    public static string _accountName { get; set; }


    public Bank(string directPage)
    {
        switch (directPage)
        {
            case "StartUpPage":
                StartUp();
                break;
        }
    }
    public Bank(string directPage, string name)
    {

        switch (directPage)
        {
            case "HomePage":
                HomePage(name);
                break;
            case "CheckAccountBalance":
                CheckAccountBalance();
                break;
            case "WithdrawBalance":
                WithdrawBalance();
                break;
            case "TransferMoney":
                TransferMoney();
                break;
            case "DepositBalance":
                DepositBalance();
                break;
        }
    }
    public static List<Account> accountlist = new List<Account>(){
        new Account(){
            account_name = "Daniel Padilla",
            account_number = 123456789,
            account_password = 12345678,
            account_balance = 10000,

        },
        new Account(){
            account_name = "Kairi Delosreyes",
            account_number = 12345678,
            account_password = 12345678,
            account_balance = 10000,

        }
        };
    public override void StartUp()
    {
        int choose = 0;
        while (true)
        {
            Console.Write("""
        Main Page
        1.Login
        2.Forgot Password
        3.Create Account
        
        Choose:
        """);

            if (int.TryParse(Console.ReadLine(), out choose))
            {
                if (choose > 0 && choose < 4)
                {
                    new AccountManager(choose);

                }
                else
                {
                    Console.WriteLine("Please enter 1 - 3 only.");
                    Thread.Sleep(500);
                    Console.Clear();
                }
            }
            else
            {
                Console.WriteLine("Invalid input.Please enter number only.");
                Thread.Sleep(500);
                Console.Clear();
            }

        }
    }
    static void HomePage(string name)
    {
        var account = accountlist.Find(x => x.account_name == _accountName);
        _accountName = name;
        int choose = 0;

        while (true)
        {
            Console.Write($"""
        Welcome {name}!!
        1.Check Account Balance
        2.Withdraw
        3.Deposit
        4.Transfer money
        5.Logout
        Choose:
        """);

            if (int.TryParse(Console.ReadLine(), out choose))
            {
                if (choose > 0 && choose < 6)
                {
                    switch (choose)
                    {
                        case 1:
                            Console.Clear();
                            new Bank("CheckAccountBalance", name);
                            break;
                        case 2:
                            Console.Clear();
                            new Bank("WithdrawBalance", name);
                            break;

                        case 3:
                            Console.Clear();
                            new Bank("DepositBalance", name);
                            break;
                        case 4:
                            Console.Clear();
                            new Bank("TransferMoney", name);
                            break;
                        case 5:
                            Console.Clear();
                            new Bank("StartUpPage");
                            break;

                    }

                }
                else
                {
                    Console.WriteLine("Please enter 1 - 5 only.");
                    Thread.Sleep(500);
                    Console.Clear();
                }
            }
            else
            {
                Console.WriteLine("Invalid input.Please enter number only.");
                Thread.Sleep(500);
                Console.Clear();
            }

        }

    }
    static void CheckAccountBalance()
    {
        var account = accountlist.Find(x => x.account_name == _accountName);
        Console.FontSize = 15;
        Console.WriteLine("Check Account Balance");
        Console.WriteLine($"Your account balance is P{account.account_balance}");
        Console.WriteLine("Press 'Any' key to back.");
        Console.ReadKey();
        Console.Clear();
    }
    static void WithdrawBalance()
    {
        int ammount = 0;
        var account = accountlist.Find(x => x.account_name == _accountName);
        Console.FontSize = 15;

        Console.WriteLine("-----Withdraw Balance-----");
        Console.WriteLine($"Your account balance is: P{account.account_balance}\n");
        Console.WriteLine("Type '0' to back.\n");
        while (true)
        {

            Console.Write("Enter ammount to withdraw: P");
            if (int.TryParse(Console.ReadLine(), out ammount))
            {
                if (ammount == 0)
                    HomePage(_accountName);
                if (account.account_balance < ammount)
                {
                    Console.WriteLine("Insufficient balance.");
                }
                else
                    break;
            }
            else
                Console.WriteLine("Invalid input.Please enter a valid ammount.");
        }

        if (ammount == 0)
        {
            Console.Clear();
            HomePage(_accountName);
        }

        Console.Write($"Are you sure(Y/N)?");
        string response = Console.ReadLine().ToLower();
        if (response == "y")
        {
            Console.WriteLine();
            account.account_balance -= ammount;
            Console.Write($"""
            Your new balance is P {account.account_balance}.
            
            Would you want to display the reciept(Y/N)?
            """);
            string printReciept = Console.ReadLine().ToLower();

            if (printReciept == "y")
            {
                Console.WriteLine();
                string reciept = PrintReciept(ammount, account.account_balance, account.account_number);

                Console.Write(reciept);
            }

            Console.WriteLine("Press 'Any' key to continue...");
            Console.ReadKey();
            Console.Clear();
            HomePage(_accountName);
        }

    }
    static void DepositBalance()
    {
        int ammount = 0;
        var account = accountlist.Find(x => x.account_name == _accountName);
        Console.FontSize = 15;

        Console.WriteLine("-----Deposit Balance-----");
        Console.WriteLine($"Your account balance is: P {account.account_balance}\n");
        Console.WriteLine("Type '0' to back.\n");
        while (true)
        {
            Console.Write("Enter ammount to deposit: P");
            if (int.TryParse(Console.ReadLine(), out ammount))
                break;
            else
                Console.WriteLine("Invalid input.Please enter a valid ammount.");
        }

        if (ammount == 0)
        {
            Console.Clear();
            HomePage(_accountName);
        }

        Console.Write($"Are you sure(Y/N)?");
        string response = Console.ReadLine().ToLower();
        if (response == "y")
        {
            Console.WriteLine();
            account.account_balance += ammount;
            Console.WriteLine($"Your new balance is P{account.account_balance}.");
            Console.WriteLine("Press 'Any' key to continue...");
            Console.ReadKey();
            Console.Clear();
            HomePage(_accountName);
        }
    }
    static void TransferMoney()
    {
        int ammount = 0;
        bool isAccountNotValid = true;
        var account = accountlist.Find(x => x.account_name == _accountName);


        while (true)
        {
            try
            {
                Console.WriteLine("-----Transfer Money-----\n");
                Console.WriteLine($"Your account balance is: P {account.account_balance}\n");
                Console.WriteLine("Type '0' to back.\n");
                Console.Write("Enter recipient account number:");
                if (int.TryParse(Console.ReadLine(), out int recipientNumber))
                {
                    if (recipientNumber == 0)
                        HomePage(_accountName);
                    while (isAccountNotValid)
                    {
                        if (account.account_number == recipientNumber)
                        {
                            Console.WriteLine("Please enter another recipient number.");
                            Thread.Sleep(500);
                            Console.Clear();
                            TransferMoney();
                        }
                        else
                        {
                            isAccountNotValid = false;
                            var findAccount = accountlist.Find(x => x.account_number == recipientNumber);
                            var isAccountExist = accountlist.Where(x => x.account_number == recipientNumber);

                            if (isAccountExist.Any())
                            {
                                while (true)
                                {
                                    Console.Write($"Do you want to transfer to {findAccount.account_name} (Y/N)?");
                                    string response = Console.ReadLine().ToLower();
                                    Console.WriteLine();
                                    if (response == "y")
                                    {
                                        Console.Write("Enter ammount to transfer :");
                                        while (true)
                                        {
                                            if (int.TryParse(Console.ReadLine(), out ammount))
                                            {
                                                while (true)
                                                {
                                                    if (ammount > account.account_balance)
                                                    {

                                                        Console.WriteLine("Insufficient balance. Please try again");
                                                    }
                                                    else
                                                    {
                                                        while (true)
                                                        {
                                                            Console.Write("Are you sure(Y/N)?");
                                                            string Response = Console.ReadLine().ToLower();
                                                            Console.WriteLine();
                                                            if (Response == "y")
                                                            {
                                                                findAccount.account_balance += ammount;
                                                                account.account_balance -= ammount;
                                                                Console.WriteLine($"Your new balance is {account.account_balance}\n");
                                                                Console.WriteLine("Press 'any' key to back.");
                                                                Console.ReadKey();
                                                                Console.Clear();
                                                                HomePage(_accountName);

                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Transaction Failed.");
                                                                Console.WriteLine("Directing to home page...");
                                                                Thread.Sleep(500);
                                                                Console.Clear();
                                                                HomePage(_accountName);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid input. Please input valid ammount.");
                                            }
                                        }
                                    }

                                    else
                                    {
                                        Console.Write("Transaction Failed.");
                                        Console.WriteLine("Directing to home page...");
                                        Thread.Sleep(500);
                                        Console.Clear();
                                        HomePage(_accountName);
                                    }
                                }

                            }
                            else
                            {
                                Console.WriteLine("Account number doesn't exist.");
                                Thread.Sleep(500);
                                Console.Clear();
                                TransferMoney();
                            }
                        }
                    }
                }

                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Thread.Sleep(500);
                    Console.Clear();
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }
    }


    static string PrintReciept(int Ammount, long Balance, long AccountNumber)
    {
        DateTime date = DateTime.Now;
        return $"""
        
        
        ---------------------------
        Account Number : {AccountNumber}
        Account name: {_accountName}
        Transaction Date : {date}
        
        Total Ammount : P {Ammount}
        Current Balance : P {Balance}
        ---------------------------
        
        
        """;

    }

}

