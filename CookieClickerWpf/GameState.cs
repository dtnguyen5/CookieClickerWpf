using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieClickerWpf
{
    internal class GameState
    {
        public double Cookies { get; set; }
        public double CookiesPerClick { get; set; }
        public double CookiesPerSecond { get; set; }
        public int TotalClicks { get; set; }
        public int TotalUpgradesBought { get; set; }
    }
}
