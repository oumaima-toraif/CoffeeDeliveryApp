using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CoffeeDeliveryApp.Data;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace CoffeeDeliveryApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage

    {
        HttpClient httpClient = new HttpClient();

        public HomePage()

        {
            InitializeComponent();

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();


            /*string url = "http://192.168.1.106/MyWebApi/api/values/getProducts";*/

            string url = Env.getProducts;
            Uri uri = new Uri(string.Format(url, string.Empty));

            HttpResponseMessage response = await httpClient.GetAsync(uri);



            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;

                List<Product> ProductList = JsonConvert.DeserializeObject<List<Product>>(result);

                MyListView.ItemsSource = ProductList;
            }

        }



        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            var details = e.Item as Product;
            await Navigation.PushAsync(new DetailsPage(details.Photo, details.Name, details.price, details.Description));
        }
        /* private async void OnCartClicked(object sender, EventArgs e)
           {
               await Navigation.PushAsync(new Orders());
           }*/
        private async void OnExitClicked(object sender, EventArgs e)

        {

            await Navigation.PushAsync(new LoginPage());
        }
        private async void OnUserIconClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserProfile());

        }


    }
}
