using Trades.Domain;

namespace Trades.App.Tests
{
    public class TradeCategorizerTest
    {
        [Fact]
        public void Categorize_ReturnsTradeCategories()
        {
            // Arrange
            var categorizeTrades = new TradeCategorizer(1000000, new[] { "LOWRISK", "MEDIUMRISK", "HIGHRISK" });
            var portfolio = new List<ITrade>
            {
                new Trade(1000001, Sector.Private),
                new Trade(1000001 , Sector.Public),
                new Trade(999999,Sector.Public),
            };

            // Act
            var result = categorizeTrades.Categorize(portfolio);

            // Assert
            Assert.Equal(new List<string> { "HIGHRISK", "LOWRISK", "MEDIUMRISK" }, result);
        }

        [Fact]
        public void Categorize_GivenEmptyPortfolio_ReturnsEmptyList()
        {
            // Arrange
            var sut = new TradeCategorizer(1000000, new[] { "LOWRISK", "MEDIUMRISK", "HIGHRISK" });
            var emptyPortfolio = new List<ITrade>();

            // Act
            var result = sut.Categorize(emptyPortfolio);

            // Assert
            Assert.Empty(result);
        }

        [Theory]
        [InlineData(Sector.Private, 500000, "")]
        [InlineData(Sector.Private, 1500000, "HIGHRISK")]
        [InlineData(Sector.Public, 500000, "MEDIUMRISK")]
        [InlineData(Sector.Public, 1500000, "LOWRISK")]        
        public void Categorize_ShouldReturnCorrectRisk_WhenPortfolioHasOneTrade(Sector sector, int value, string expected)
        {
            // Arrange
            var categorizer = new TradeCategorizer(1000000, new[] { "LOWRISK", "MEDIUMRISK", "HIGHRISK" });
            var trade = new Trade(value, sector);
            var portfolio = new List<ITrade>() { trade };

            // Act
            var result = categorizer.Categorize(portfolio);

            // Assert
            Assert.Single(result);
            Assert.Equal(expected, result.First());
        }
    }
}