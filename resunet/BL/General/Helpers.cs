using System.Transactions;
public static class Helpers
{
    public static int? StringToIntDef(string str, int? def)
    {
        int value;
        if(int.TryParse(str, out value))
            return value;
        return def;
    } 
    public static TransactionScope CreateTransactionScope(int seconds=6000)
    {
        return new TransactionScope(TransactionScopeOption.Required, 
                                    new TimeSpan(0,0,seconds),
                                    TransactionScopeAsyncFlowOption.Enabled);
    }
}