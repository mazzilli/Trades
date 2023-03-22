namespace Trades.Domain
{
    public interface ITrade
    {
        double Value { get; }
        string ClientSector { get; }
    }

}
