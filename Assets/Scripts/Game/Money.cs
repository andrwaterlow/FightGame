public class Money 
{
    private int _currentMoney;

    public void MoneyUp(int cost)
    {
        _currentMoney += cost;
    }

    public int GetMoney()
    {
        return _currentMoney;
    }
}
