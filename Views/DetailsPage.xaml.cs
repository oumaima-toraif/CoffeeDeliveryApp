using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoffeeDeliveryApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        HttpClient httpClient = new HttpClient();
        public DetailsPage(string photo, string nom, int prix, string Description)
        {
            InitializeComponent();
            ProductImage.Source = photo;
            ProductName.Text = nom;
            ProductPrice.Text = prix.ToString() + " " + "MAD";
            ProductDes.Text = Description;
        }
        /* string url = Env.getProduct + "?id=";
           Uri uri = new Uri(string.Format(url, string.Empty));

           HttpResponseMessage response = await httpClient.GetAsync(uri);


           if (response.IsSuccessStatusCode)
           {
               string result = response.Content.ReadAsStringAsync().Result;

               Product Produit = JsonConvert.DeserializeObject<Product>(result);

               BindingContext = Produit;
           }
*/
        private async void OnOrderClicked(object sender, EventArgs e)

        {
            
            string result = await DisplayPromptAsync("Question", "How many Coffee Cups of this  do you want to order ?", initialValue: "1", maxLength: 2,keyboard:Keyboard.Numeric);


          





        }
    } }
    
