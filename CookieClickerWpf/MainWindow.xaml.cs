using System;
using System.Windows;
using System.Windows.Threading;

namespace CookieClickerWpf
{
    public partial class MainWindow : Window
    {
        GameState state = new GameState();
        DispatcherTimer timer = new DispatcherTimer();

        private void CookieButton_Click(object sender, RoutedEventArgs e)
        {
            state.Cookies += state.CookiesPerClick;
            state.TotalClicks++;
            UpdateUI();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            state.Cookies += state.CookiesPerSecond;
            UpdateUI();
        }

        private void ShopButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Obchod není hotový.");
        }

        public void UpdateUI()
        {
            CookiesText.Text = state.Cookies + " sušenek";
            PerClickText.Text = "Za kliknutí: " + state.CookiesPerClick;
            PerSecondText.Text = "Produkce: " + state.CookiesPerSecond + " / s";
            TotalClicksText.Text = "Kliknutí: " + state.TotalClicks;
            TotalUpgradesText.Text = "Zakoupená vylepšení: " + state.TotalUpgradesBought;
            TotalEarnedText.Text = "Celkem získáno: " + state.Cookies;
        }
    }
}