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
    public class BookingRepository : IBookingRepository
    {
        public async Task<List<Booking>> GetBookingsBySpaceId(int idspace)
        {
            try
            {
                string apiUrl = $"https://c6m3zvixpg.execute-api.us-east-1.amazonaws.com/prod/bookings/getbyspaceid/{idspace}";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Accept = "application/json";

                StreamReader responseReader = new StreamReader(request.GetResponse().GetResponseStream());
                string responseData = await responseReader.ReadToEndAsync();
                responseReader.Close();

                return JsonConvert.DeserializeObject<List<Booking>>(responseData);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> CreateBooking(Booking bookingObject)
        {
            string s = JsonConvert.SerializeObject(bookingObject);
            try
            {
                var client = new RestClient("https://c6m3zvixpg.execute-api.us-east-1.amazonaws.com/prod/bookings");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(bookingObject), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    ResponseLambdaObject responseLambdaObject = JsonConvert.DeserializeObject<ResponseLambdaObject>(response.Content);
                    if (responseLambdaObject.affectedRows == 0)
                    {
                        return "L'horaire de la réservation n'est pas disponible!";
                    }
                    else
                    {
                        return "Réservation effectuée !";
                    }
                   
                }
                else
                {
                    return "Erreur lors de la création de la réservation";
                }

            }
            catch (Exception ex)
            {
                return "Erreur lors de la création de la réservation";
            }
        }
    }
}


public class ResponseLambdaObject
{
    public int fieldCount { get; set; }
    public int affectedRows { get; set; }
    public int insertId { get; set; }
    public int serverStatus { get; set; }
    public int warningCount { get; set; }
    public string message { get; set; }
    public bool protocol41 { get; set; }
    public int changedRows { get; set; }
}
