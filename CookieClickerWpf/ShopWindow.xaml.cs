using System;
using System.Windows;

namespace CookieClickerWpf
{
    public partial class ShopWindow : Window
    {
        GameState state;

        public ShopWindow(GameState stateFromMain)
        {
            InitializeComponent();
            state = stateFromMain;
            UpdateTexts();
        }
        
        public void UpdateTexts()
        {
            CookiesInShopText.Text = "Sušenky: " + state.Cookies;

            PriceCursorText.Text = state.PriceCursor.ToString();
            PriceDoubleText.Text = state.PriceDouble.ToString();
            PriceGrandmaText.Text = state.PriceGrandma.ToString();
            PriceBakeryText.Text = state.PriceBakery.ToString();
            PriceFactoryText.Text = state.PriceFactory.ToString();

            BuyCursorButton.IsEnabled = state.Cookies >= state.PriceCursor;
            BuyDoubleButton.IsEnabled = state.Cookies >= state.PriceDouble;
            BuyGrandmaButton.IsEnabled = state.Cookies >= state.PriceGrandma;
            BuyBakeryButton.IsEnabled = state.Cookies >= state.PriceBakery;
            BuyFactoryButton.IsEnabled = state.Cookies >= state.PriceFactory;
        }
        
        private void RefreshAll()
        {
            UpdateTexts();
            if (Owner is MainWindow mw)
            {
                mw.UpdateUI();
            }
        }

        private int NewPrice(int oldPrice)
        {
            int newPrice = (int)Math.Round(oldPrice * 1.5);
            if (newPrice < 1)
            {
                newPrice = 1;
            }
            return newPrice;
        }

        private void NotEnoughCookies()
        {
            MessageBox.Show("Nemáš dost sušenek.");
        }

        private void BuyCursor_Click(object sender, RoutedEventArgs e)
        {
            if (state.Cookies < state.PriceCursor)
            {
                NotEnoughCookies();
                UpdateTexts();
                return;
            }

            state.Cookies -= state.PriceCursor;
            state.CookiesPerClick += 1;
            state.TotalUpgradesBought += 1;
            state.PriceCursor = NewPrice(state.PriceCursor);

            RefreshAll();
        }

        private void BuyDouble_Click(object sender, RoutedEventArgs e)
        {
            if (state.Cookies < state.PriceDouble)
            {
                NotEnoughCookies();
                UpdateTexts();
                return;
            }

            state.Cookies -= state.PriceDouble;
            state.CookiesPerClick += 5;
            state.TotalUpgradesBought += 1;
            state.PriceDouble = NewPrice(state.PriceDouble);

            RefreshAll();
        }

        private void BuyGrandma_Click(object sender, RoutedEventArgs e)
        {
            if (state.Cookies < state.PriceGrandma)
            {
                NotEnoughCookies();
                UpdateTexts();
                return;
            }

            state.Cookies -= state.PriceGrandma;
            state.CookiesPerSecond += 1;
            state.TotalUpgradesBought += 1;
            state.PriceGrandma = NewPrice(state.PriceGrandma);

            RefreshAll();
        }

        private void BuyBakery_Click(object sender, RoutedEventArgs e)
        {
            if (state.Cookies < state.PriceBakery)
            {
                NotEnoughCookies();
                UpdateTexts();
                return;
            }

            state.Cookies -= state.PriceBakery;
            state.CookiesPerSecond += 5;
            state.TotalUpgradesBought += 1;
            state.PriceBakery = NewPrice(state.PriceBakery);

            RefreshAll();
        }

        private void BuyFactory_Click(object sender, RoutedEventArgs e)
        {
            if (state.Cookies < state.PriceFactory)
            {
                NotEnoughCookies();
                UpdateTexts();
                return;
            }

            state.Cookies -= state.PriceFactory;
            state.CookiesPerSecond += 25;
            state.TotalUpgradesBought += 1;
            state.PriceFactory = NewPrice(state.PriceFactory);

            RefreshAll();
        }
    }
}