using GoStyle.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace GoStyle.Services
{
    class UserService
    {
        private static UserService _userService;
        private static User _user;
        HttpClient _client;

        private UserService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://51.15.244.170:12053/api/auth/");
        //   _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
        }

        public static UserService getInstance()
        {
            if (_userService is null)
            {
                _userService = new UserService();
                return _userService;
            }
            else
            {
                return _userService;
            }
        }

        public User getUser()
        {
            return _user;
        }

        public bool Connexion(String username, String pass)
        {
            if(_user == null)
            {
                //String passHash = Convert.ToBase64String(SHA512.Create().ComputeHash(Encoding.UTF8.GetBytes(pass)));
                Login login = new Login(username, pass);
                string jsonString = JsonSerializer.Serialize(login);
                StringContent stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                stringContent.Headers.Add("Content-Length", jsonString.Length.ToString());
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress+"login", stringContent).Result;

                string responseBody = response.Content.ReadAsStringAsync().Result;
                JObject jObject = JObject.Parse(responseBody);
                _user = new User();
                _user.Tocken = (String)jObject["token"];
                ReductionServices.GetInstance().SetTocken(_user.Tocken);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CreateUser(String login, String pass, String fn, String ln, String number)
        {
            if (_user is null)
            {
                String passHash = Convert.ToBase64String(SHA512.Create().ComputeHash(Encoding.UTF8.GetBytes(pass)));
                Register register = new Register(login, passHash, fn, ln, number);
                string jsonString = JsonSerializer.Serialize(register);
                StringContent stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                stringContent.Headers.Add("Content-Length", jsonString.Length.ToString());
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "register", stringContent).Result;
                response.EnsureSuccessStatusCode();
                string responseBody = response.Content.ReadAsStringAsync().Result;

                ReductionServices.GetInstance().SetTocken(_user.Tocken);
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class Login
    {
        public String username { get; set; }
        public String password { get; set; }

        public Login(String username, String password)
        {
            this.username = username;
            this.password = password;
        }
        

    }

    class Register
    {
        public String username { get; set; }
        public String password { get; set; }
        public String email { get; set; }

        public Register(String login, String pass, String fn, String ln, String number)
        {
            this.username = fn + " " + ln; ;
            this.password = pass;
            this.email = login;
        }

        class Res
        {

        }
    }
}
