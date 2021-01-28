using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Xamarin.Entity;
using Xamarin.Repository.Interfaces;

namespace Xamarin.Repository
{
    public class UserRepository : IUserRepository
    {
        public ICollection<User> GetUsers()
        {
            try
            {
                string apiUrl = "https://c6m3zvixpg.execute-api.us-east-1.amazonaws.com/prod/users";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Accept = "application/json";

                StreamReader responseReader = new StreamReader(request.GetResponse().GetResponseStream());
                string responseData = responseReader.ReadToEnd();
                responseReader.Close();

                return JsonConvert.DeserializeObject<List<User>>(responseData);
            }
            catch (Exception ex)
            {
                return null;
            } 
        }
    }
}
