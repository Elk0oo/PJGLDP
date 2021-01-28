using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Entity;
using Xamarin.Repository.Interfaces;

namespace Xamarin.Repository
{
    public class SpaceRepository : ISpaceRepository
    {

        public async Task<List<Space>> GetSpaces()
        {
            try
            {
                string apiUrl = "https://c6m3zvixpg.execute-api.us-east-1.amazonaws.com/prod/spaces";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Accept = "application/json";

                StreamReader responseReader = new StreamReader(request.GetResponse().GetResponseStream());
                string responseData = await responseReader.ReadToEndAsync();
                responseReader.Close();

                return JsonConvert.DeserializeObject<List<Space>>(responseData);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Space> GetOneSpace(int idSpace)
        {
            try
            {
                string apiUrl = $"https://c6m3zvixpg.execute-api.us-east-1.amazonaws.com/prod/spaces/{idSpace}";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Accept = "application/json";

                StreamReader responseReader = new StreamReader(request.GetResponse().GetResponseStream());
                string responseData = responseReader.ReadToEnd();
                responseReader.Close();

                return JsonConvert.DeserializeObject<Space>(responseData);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> UpdateSpace(Space spaceObject)
        {
            try
            {
                string apiUrl = "https://c6m3zvixpg.execute-api.us-east-1.amazonaws.com/prod/spaces/{spaceObject.Id}";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
                request.Method = "PUT";
                request.ContentType = "application/json";
                request.Accept = "application/json";

                string data = "Name" + spaceObject.Name + ",Description" + spaceObject.Description + ",Picture" + spaceObject.Picture + ",Type" + spaceObject.Type + ",Capacity" + spaceObject.Capacity+",CreatedAt " + spaceObject.CreatedBy;
                  
                var dataEncoded = Encoding.Default.GetBytes(data);
           
                request.ContentLength = dataEncoded.Length;

                StreamReader responseReader = new StreamReader(request.GetResponse().GetResponseStream());
                string responseData = responseReader.ReadToEnd();
                responseReader.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteSpace(int idSpace)
        {
            try
            {
                string apiUrl = "https://c6m3zvixpg.execute-api.us-east-1.amazonaws.com/prod/spaces/{idSpace}";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
                request.Method = "DELETE";
                request.ContentType = "application/json";
                request.Accept = "application/json";

                StreamReader responseReader = new StreamReader(request.GetResponse().GetResponseStream());
                string responseData = responseReader.ReadToEnd();
                responseReader.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> CreateSpace(Space spaceObject)
        {
            try
            {
                var client = new RestClient("https://c6m3zvixpg.execute-api.us-east-1.amazonaws.com/prod/spaces");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(spaceObject), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
