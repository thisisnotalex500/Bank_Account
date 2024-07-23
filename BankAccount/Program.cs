using Classes;
using System;
using System.Reflection.Metadata.Ecma335;

public class Program
{
    static void Main(string[] args)
    {
        var account = new BankAccount("Alex", 1000);

        try//called the try catch meant to catch any problems with code
        {
            account.PrintTransactions();//Problem/Object you're looking for

        }
        catch//called the try catch meant to catch any problems with code
        {
            Console.WriteLine("No Transactions made");//If it catches the problem you have have it ConsoleWriteLine ""any message that best represents the problem/solution
        }

        Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");//Console.WriteLine will string together and output Account Number, Account Owner, and Account Balance.
        account.MakeWithdrawal(500, DateTime.Now, "Rent payment");//My(Alex's)Account makes a 500$ withdrawal on a certain Date with a not saying "Rent Payment"
        Console.WriteLine(account.Balance);//Outputting New Account Balance
        account.MakeDeposit(100, DateTime.Now, "Friend paid me back");//Account makes a 100$ Dollar deposit at certain time note is "Friend Paid me back"
        Console.WriteLine(account.Balance);//Outputting New Account Balance

        BankAccount invalidAccount;//This is BankAccount class and the variable named Invalid Account
        try
        {
            invalidAccount = new BankAccount("invalid", -55);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine("Exception caught creating account with negative balance");
            Console.WriteLine(e.ToString);
            return;
        }

        try
        {
            account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine("Exception caught trying to overdraw");
            Console.WriteLine(e.ToString());
        }


        try
        {
            account.MakeWithdrawal(8, DateTime.Now, "thank you");
        }
        catch
        {
            Console.WriteLine("Error on taking money out");
        }

        account.MakeDeposit(+1, new DateTime(2077, 10, 19), "thank you");

        account.PrintTransactions();


    }




}

