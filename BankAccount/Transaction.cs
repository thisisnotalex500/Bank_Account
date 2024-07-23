namespace Classes;

public class Transaction
{
    public decimal Amount { get; } //Property
    public DateTime Date { get; }//Property
    public string Notes { get; }//Property

    public Transaction(decimal amount, DateTime date, string note)
    {
        Amount = amount;
        Date = date;
        Notes = note;
    }
}
