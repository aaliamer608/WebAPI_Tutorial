using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace WebAPI_Tutorial.Models
{
    public class RegisterBindingModel
    {
    }


    class RegisterModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    class RegisterService
    {
        [HttpPost]
        public async Task Register(string username, string password, string confirmPassword)
        {
            RegisterModel model = new RegisterModel
            {
                ConfirmPassword = confirmPassword,
                Password = password,
                UserName = username
            };

            HttpWebRequest request = new HttpWebRequest(new Uri(String.Format("{0}api/Account/Register", Constants.BaseAddress)));
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            string json = JsonConvert.SerializeObject(model);
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            using (Stream stream = await request.GetRequestStreamAsync())
            {
                stream.Write(bytes, 0, bytes.Length);
            }

            try
            {
                await request.GetResponseAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}