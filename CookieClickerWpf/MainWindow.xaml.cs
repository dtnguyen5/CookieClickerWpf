using System;
using System.Windows;
using System.Windows.Threading;

namespace CookieClickerWpf
{
    public partial class MainWindow : Window
    {
        GameState state;
        DispatcherTimer timer;
        ShopWindow shop;

        public MainWindow()
        {
            InitializeComponent();

            state = new GameState();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

            UpdateUI();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateUI();
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (state.CookiesPerSecond > 0)
            {
                state.Cookies = state.Cookies + state.CookiesPerSecond;
                state.TotalCookiesEarned = state.TotalCookiesEarned + state.CookiesPerSecond;
                UpdateUI();
            }
        }

        private void CookieButton_Click(object sender, RoutedEventArgs e)
        {
            state.Cookies = state.Cookies + state.CookiesPerClick;
            state.TotalCookiesEarned = state.TotalCookiesEarned + state.CookiesPerClick;
            state.TotalClicks = state.TotalClicks + 1;

            UpdateUI();
        }

        private void ShopButton_Click(object sender, RoutedEventArgs e)
        {
            if (shop == null || shop.IsVisible == false)
            {
                shop = new ShopWindow(state);
                shop.Owner = this;
                shop.Show();
            }
            else
            {
                shop.Activate();
            }

            shop.UpdateTexts();
        }

        public void UpdateUI()
        {
            CookiesText.Text = state.Cookies + " sušenek";
            PerClickText.Text = "Za kliknutí: " + state.CookiesPerClick;
            PerSecondText.Text = "Produkce: " + state.CookiesPerSecond + " / s";

            TotalClicksText.Text = "Kliknutí: " + state.TotalClicks;
            TotalUpgradesText.Text = "Zakoupená vylepšení: " + state.TotalUpgradesBought;
            TotalEarnedText.Text = "Celkem získáno: " + state.TotalCookiesEarned;

            if (shop != null && shop.IsVisible)
            {
                shop.UpdateTexts();
            }
        }
    }
}