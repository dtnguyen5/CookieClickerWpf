namespace CookieClickerWpf
{
    public class GameState
    {
        public int Cookies { get; set; }
        public int CookiesPerClick { get; set; }
        public int CookiesPerSecond { get; set; }

        public int TotalClicks { get; set; }
        public int TotalUpgradesBought { get; set; }
        public int TotalCookiesEarned { get; set; }
        
        public int PriceCursor { get; set; }
        public int PriceDouble { get; set; }
        public int PriceGrandma { get; set; }
        public int PriceBakery { get; set; }
        public int PriceFactory { get; set; }

        public GameState()
        {
            Cookies = 0;
            CookiesPerClick = 1;
            CookiesPerSecond = 0;

            TotalClicks = 0;
            TotalUpgradesBought = 0;
            TotalCookiesEarned = 0;

            PriceCursor = 10;
            PriceDouble = 50;
            PriceGrandma = 100;
            PriceBakery = 500;
            PriceFactory = 2500;
        }
    }
}