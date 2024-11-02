using Maui.Google.Services;
using Maui.Google.Views;

namespace Maui.Google
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private readonly IPrivacyAndConsentService _privacyAndConsentService;

        public MainPage()
        {
            InitializeComponent();
            _privacyAndConsentService = new PrivacyAndConsentService();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_privacyAndConsentService.CanRequestAds())
            {
                AdBannerView adBannerView = new() 
                {
                    AdUnitId = "ca-app-pub-3940256099942544/2934735716"
                };

                Grid.SetRow(adBannerView, 1);
                mainGrid.Children.Add(adBannerView);
            }
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
