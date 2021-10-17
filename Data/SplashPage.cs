using System;
using System.Collections.Generic;
using System.Text;
using CoffeeDeliveryApp.Views;
using Xamarin.Forms;

namespace CoffeeDeliveryApp.Data
{
    public class SplashPage : ContentPage
    {
        Image splashImage;
        public SplashPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            var sub = new AbsoluteLayout();
            splashImage = new Image
            {
                Source = "splashicon.jpg",
                WidthRequest = 100,
                HeightRequest = 100
            };
            AbsoluteLayout.SetLayoutFlags(splashImage, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(splashImage, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            sub.Children.Add(splashImage);
            this.BackgroundColor = Color.FromHex("#FFFFFF");
            this.Content = sub;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await splashImage.ScaleTo(2, 2000);
            splashImage.Opacity = 0;
            await splashImage.FadeTo(2, 4000);
            /*await splashImage.ScaleTo(2, 1500, Easing.Linear);
            await splashImage.ScaleTo(150, 1200, Easing.Linear);*/
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}
