namespace Trades.Domain
{
    public class Trade : ITrade
    {
        public Trade()
        {
            
        }
        public Trade(decimal value, Sector clientSector)
        {
            Value = value;
            ClientSector = clientSector;
        }

        public decimal Value { get; set; }

        public Sector ClientSector { get; set; }

    }
}
