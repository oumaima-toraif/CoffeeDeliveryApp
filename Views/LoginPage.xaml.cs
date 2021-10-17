using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CoffeeDeliveryApp.Data;
using Xamarin.Essentials;

namespace CoffeeDeliveryApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage

    {
        HttpClient httpClient = new HttpClient();
        public LoginPage()
        {
            InitializeComponent();
        }
        async void OnSignUpButtonClicked(object sender, EventArgs e)

        {

            await Navigation.PushAsync(new SignUpPage());

        }
        async void OnLoginClicked(object sender, EventArgs e)

        {
            Uri uri;
            string json;
            StringContent content;
            HttpResponseMessage response = null;
            string link = Env.CheckUser;
            uri = new Uri(string.Format(link, string.Empty));
            if (usernameEntry.Text == null || passwordEntry.Text == null)
            {
                await DisplayAlert("Login Failed ", "Enter your informations", "OK", "Cancel");
            }
            else
            {
                User ru = new User();
                ru.Username = usernameEntry.Text.Trim();
                ru.Password = passwordEntry.Text.Trim();
                ru.Phone = null;
                ru.ConfirmPassword = null;
                ru.UserID =0;
                json = JsonConvert.SerializeObject(ru);
                content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await httpClient.PostAsync(uri, content);
                string result = "";
                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsStringAsync().Result;
                    User ru1 = JsonConvert.DeserializeObject<User>(result);
                    await SecureStorage.SetAsync("id_user",ru1.UserID.ToString());
                    /*if (ru1.Username == ru.Username && ru1.Password == ru.Password)
                        await Navigation.PushAsync(new HomePage());
                    else
                    {
                        if (ru1.Username != ru.Username)


                         else if (ru1.Password != ru.Password)
                            await DisplayAlert("PASSWORD ERROR", "TRY AGAIN", "OK", "CANCEL");
                    }*/

                    if (ru1==null)
                        await DisplayAlert("Failed", "Information incorrect", "OK");
                    
                    else
                    {
                        
                        await Navigation.PushAsync(new HomePage());
                    }

                }
                else
                    await DisplayAlert("LOGIN ERROR ", "Try AGAIN", "OK", "CANCEL");

            }
               


            }
    }
}