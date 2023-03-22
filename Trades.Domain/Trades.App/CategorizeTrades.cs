using Trades.Domain;

namespace Trades.App
{
    public class TradeCategorizer : ITradeCategorizer
    {
        private readonly decimal _valueClassification;
        private readonly string[] _classifications;

        /// <summary>
        /// Categorize the trade by analyzing the value and the customer sector
        /// </summary>
        /// <param name="valueClassification">Risk reference value</param>
        /// <param name="classifications">Low-risk, medium-risk, or high-risk classifications, in that order</param>
        public TradeCategorizer(decimal valueClassification, string[] classifications)
        {
            _valueClassification = valueClassification;
            _classifications = classifications;
        }

        /// <summary>
        /// Categorizes past values
        /// </summary>
        /// <param name="portfolio">list of trades</param>
        /// <returns>trade risk</returns>
        public IEnumerable<string> Categorize(List<ITrade> portfolio)
        {
            return portfolio.Select(trade => Classify(trade));
        }

        /// <summary>
        /// classifies the operation risk
        /// </summary>
        /// <param name="trade">Trade</param>
        /// <returns>Classification</returns>
        private string Classify(ITrade trade)
        {
            return trade.ClientSector switch
            {
                Sector.Private => trade.Value > _valueClassification ? _classifications[2] : string.Empty,
                Sector.Public => trade.Value > _valueClassification ? _classifications[0] : _classifications[1],
                _ => string.Empty,
            };

        }
    }
}