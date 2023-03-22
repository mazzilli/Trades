using Trades.Domain;

namespace Trades.App
{
    public class CategorizeTrades
    {
        const int _valueClassification = 1000000;
        readonly string[] _classifications = { "LOWRISK", "MEDIUMRISK", "HIGHRISK" };

        public List<string> Categorize(List<ITrade> portfolio)
        {
            // Trade´s return with same size array
            var tradeCategories = new string[portfolio.Count];

            // run through the portfolio to classificate
            Parallel.For(0, portfolio.Count, async (i) =>
            {
                // apply the rules
                tradeCategories[i] = await Classificate(portfolio[i]);
            });

            return tradeCategories.ToList();
        }

        /// <summary>
        /// Classificate the trade
        /// </summary>
        /// <param name="trade"></param>
        /// <returns>The risk of the trade("LOWRISK", "MEDIUMRISK", "HIGHRISK")</returns>
        private async Task<string> Classificate(ITrade trade)
        {
            return await Task.Run(() =>
            {
                return trade.ClientSector switch
                {
                    "Private" => trade.Value > _valueClassification ? _classifications[2] : string.Empty,
                    "Public" => trade.Value > _valueClassification ? _classifications[0] : _classifications[1],
                    _ => string.Empty,
                };
            });
        }
    }
}