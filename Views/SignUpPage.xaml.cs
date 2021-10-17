using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeDeliveryApp.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Newtonsoft.Json;

namespace CoffeeDeliveryApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        HttpClient httpClient = new HttpClient();
        public SignUpPage()
        {
            InitializeComponent();
        }
        async void onClickedLogin(object sender, EventArgs e)

        {

            await Navigation.PopAsync();

        }
        async void onConfirmClicked(object sender, EventArgs e)
        {
            Uri uri, uri1;
            string json;
            StringContent content;
            HttpResponseMessage response = null;
            string linq = Env.CheckUsername;
            string link = Env.UserSignUp;
            uri = new Uri(string.Format(linq, string.Empty));
            uri1 = new Uri(string.Format(link, string.Empty));
            if (PhoneEntry.Text == null || UsernameEntry.Text == null || PasswordEntry.Text == null || PasswdEntry.Text == null)
            {
                await DisplayAlert("Registration Failed ", "Enter your informations", "OK", "Cancel");
            }
            else if (PasswordEntry.Text != PasswdEntry.Text)
            {
                await DisplayAlert("Registration Failed", "Password Dismatch", "OK", "Cancel");
            }
            else
            {
                User ru = new User();
                ru.Username = UsernameEntry.Text.Trim();
                ru.Phone = PhoneEntry.Text.Trim();
                ru.Password = PasswordEntry.Text.Trim();
                ru.ConfirmPassword = PasswdEntry.Text.Trim();

                json = JsonConvert.SerializeObject(ru);
                content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await httpClient.PostAsync(uri, content);
                string result = "";
                if (response.IsSuccessStatusCode)
                {
                    /* result = response.Content.ReadAsStringAsync().Result;
                    // User ru1 = JsonConvert.DeserializeObject<User>(result);
                     await DisplayAlert("registration successful", "added", "Ok");
                     await Navigation.PopAsync();*/
                    result = response.Content.ReadAsStringAsync().Result;
                    bool ru1= JsonConvert.DeserializeObject<bool>(result);
                    if (!ru1)
                    {
                        
                        json = JsonConvert.SerializeObject(ru);
                        content = new StringContent(json, Encoding.UTF8, "application/json");
                        response = await httpClient.PostAsync(uri1, content);
                        string result1 = "";
                        if (response.IsSuccessStatusCode)
                        {
                            result1 = response.Content.ReadAsStringAsync().Result;
                            await DisplayAlert("registration successful", "added", "Ok");
                            await Navigation.PopAsync();

                        }
                        else

                            await DisplayAlert("NOT ADDED", "Try AGAIN", "Ok", "Cancel");
                    }


                    else
                    
                        await DisplayAlert("USERNAME ALREADY EXISTS", "ENTER ANOTHER ONE ", "OK", "CANCEL");

                    

                    }
                else
                
                  await DisplayAlert("ERROR", "Try Again", "OK","CANCEL");
                
                    


                }
               
            }
            



        }
    }
