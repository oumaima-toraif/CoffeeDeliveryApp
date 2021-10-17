using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using CoffeeDeliveryApp.Data;
using Newtonsoft.Json;

namespace CoffeeDeliveryApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserProfile : ContentPage
    {
        HttpClient httpClient = new HttpClient();
        public UserProfile()
        {
            InitializeComponent();
            
         }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            int id_user;
            var id_user1 = await SecureStorage.GetAsync("id_user");
            if (id_user1 != null)
            {

                id_user = Convert.ToInt32(id_user1);
                string url = Env.getUserProfile + "?id=" + id_user;
                Uri uri = new Uri(string.Format(url, string.Empty));

                HttpResponseMessage response = await httpClient.GetAsync(uri);



                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    User u = JsonConvert.DeserializeObject<User>(result);
                    Username.Text = u.Username;
                    Phone.Text = u.Phone;
                    
                }
            }

        }
        private async void OnProfileUpdate(object sender, EventArgs e) 
        {

           // await Navigation.PushAsync(new ProfileUserUpdate());

        }




    }

}
