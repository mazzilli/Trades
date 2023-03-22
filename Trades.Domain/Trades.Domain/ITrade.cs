namespace Trades.Domain
{
    public interface ITrade
    {
        decimal Value { get; }
        Sector ClientSector { get; }
    }

}
