using Microsoft.AspNetCore.Mvc;
using Trades.App;
using Trades.Domain;

namespace Trade.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradeClassification : ControllerBase
    {
        private readonly ITradeCategorizer tradeClassfication;
        public TradeClassification(ITradeCategorizer trade)
        {
            tradeClassfication = trade ?? throw new ArgumentNullException(nameof(trade));
        }

        [HttpPost("GetOne")]
        public IEnumerable<string> Post(ITrade trade) => tradeClassfication.Categorize(new List<ITrade>() { trade });

        [HttpPost("GetMany")]
        public IEnumerable<string> Post(List<Trades.Domain.Trade> portfolio)
        {
            var cast = portfolio.Select(p=> p as ITrade).ToList();
            return tradeClassfication.Categorize(cast);
        }

    }
}
