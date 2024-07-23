using System.ComponentModel;
using System.Transactions;
namespace Classes;
public class BankAccount //Defines the Class I'm creating.


{
    private decimal _balance = 0;
    private int s_accountNumberSeed = 1234567890;//The accountNumberSeed is a data member. It's private which means it can only be accessed by code inside the BankAccount class.
                                                 //s denotes static while _ makes it a private field




    // Everything inside the bracket follows the class declaration.
    // Defining behavior
    public string Number { get; } //1. Property
    public string Owner { get; set; } //2. Property
    public decimal Balance //3. Property
    //Properties are data and elements that can have code that enforces validation or other rules.
    {
        get//rules
        {

            foreach (var item in _allTransactions)//For each item in _allTransactions
            {
                _balance += item.Amount;//Summing the values/balance of all transactions
            }
            return _balance;//Given updated balance after summing up all tranactions
        }
        set
        {
            _balance = value;//allowing change with the variable so it's not just seen as "seen"
        }

    }


    //Methods are blocks of code that perform a single function.

    public BankAccount(string name, decimal initialBalance)//Creating new object BankAccount type||This means defining a constructor a constructor has the same name as the class and assigns values.
    {
        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;//Calling and brining back account Number from program file||The "++" is for each account called the end number is increased by 1+ so that each account created is different

        Owner = name;//String for my name "Alex"
        MakeDeposit(initialBalance, DateTime.Now, "Initial balance");//Calling back to find entered in initial balance date.
    }

    private List<Transaction> _allTransactions = new List<Transaction>();//T is a new Declaration it introduces a new variable or constant
    public void MakeDeposit(decimal amount, DateTime date, string note)//Implement the MakeDeposit and MakeWithdrawal methods rules these will enforce initial balance must be positive. And any withdrawal must note create a negative balance.
                                                                       //MakeDeposit method throws an exception if the amount of the deposit isn't greater than 0.
    {
        if (amount <= 0)//If amount you deposit is equal to or less than zero. You will trigger the 1st part of the "if" statement.
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");//You trigger the "AOORE class that causes a specified error message
        }
        var deposit = new Transaction(amount, date, note);//If you trigger the 2nd part of the "if" statement you will be able to deposit amount enter in date and add note. 
        _allTransactions.Add(deposit);//Then your deposit will be added to _allTransactions
    }

    public void MakeWithdrawal(decimal amount, DateTime date, string note)//You're making a withdrawal you input (amount,date,and a note)
    {
        if (amount <= 0)//if the amount you withdrawal is less than or equal to zero. You trigger the 1st part of the "if" statement
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");//you throw a AOORE class which displays this error message.
        }
        if (Balance - amount < 0)//If you don't trigger the 1st "if" but the 2nd part of the "if" which is the amount you withdrawal from your account leaves you in the negative below zero.
        {
            throw new InvalidOperationException("Not sufficient funds for this withdrawal");//You throw IOE class with a specified error message
        }
        var withdrawal = new Transaction(-amount, date, note);//if you don't hit those 2 "if statements" two you will be able to withdrawal (-amount, input date, and leave note)
        _allTransactions.Add(withdrawal);//which will add a withdrawal transaction to _allTransactions

    }
    public void PrintTransactions()//You're printing each transaction.
    {
        if (!_allTransactions.Any())//"!"is a logical and negation operator."Any" determines whether a sequence contains any elements.Returns true if the source sequence contains any elements;otherwise false. From (_allTransactions)

        {
            throw new ArgumentOutOfRangeException(nameof(Transaction), "no transactions yet"); //If false you trigger 1st "if" statement you will throw AOORE class for transaction which will display error message
        }
        _allTransactions.ForEach(transaction =>//If you don't trigger the false and trigger the 2nd part you will hit_allTransactions.ForEach(transaction=> which means performs the specified action on each element of the List<T>
        //Means a list of objects that can be accessed by index. Provides methods to search, sort, and manipulate lists. 
        {
            Console.WriteLine($"Amount:{transaction.Amount},{transaction.Date},{transaction.Notes}");//Now this specified action outputs the specified string value, followed by the current line terminator, to the standard output stream.
            //Which means outputting the "Transaction Amount", "Transaction Date", and "Transaction Notes".

        });
    }



}
