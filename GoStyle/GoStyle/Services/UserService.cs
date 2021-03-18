using GoStyle.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;

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
            _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("*/*"));
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
            if(_user is null)
            {
                //String passHash = Convert.ToBase64String(SHA512.Create().ComputeHash(Encoding.UTF8.GetBytes(pass)));
                String passHash = "Tamere";
                username = "tdarty";
                Login login = new Login(username, passHash);
                HttpResponseMessage responce = _client.PostAsJsonAsync<Login>("login", login).Result;
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
        public String Username { get; set; }
        public String Password { get; set; }

        public Login(String username, String password)
        {
            this.Username = username;
            this.Password = password;
        }
        

    }
}
