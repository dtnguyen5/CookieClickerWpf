using System;

namespace CookieClickerWpf
{
    public class Upgrade
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int BoughtCount { get; set; }

        public int AddPerClick { get; set; }
        public int AddPerSecond { get; set; }

        public Upgrade(string name, string description, int price, int addPerClick, int addPerSecond)
        {
            Name = name;
            Description = description;
            Price = price;
            AddPerClick = addPerClick;
            AddPerSecond = addPerSecond;
            BoughtCount = 0;
        }

        public void Apply(GameState state)
        {
            state.CookiesPerClick += AddPerClick;
            state.CookiesPerSecond += AddPerSecond;

            BoughtCount++;
            state.TotalUpgradesBought++;
        }

        public void IncreasePrice()
        {
            Price = (int)Math.Round(Price * 1.5);

            if (Price < 1)
            {
                Price = 1;
            }
        }
    }
}