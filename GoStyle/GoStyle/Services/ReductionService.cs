using GoStyle.Models;
using Tiny.RestClient;
using System.Net.Http;

namespace GoStyle.Services
{
    public class ReductionServices
    {
        public Reduction GetReductionAsync(string uId)
        {
            TinyRestClient client = new TinyRestClient(new HttpClient(), "http://127.0.0.1:8000/QRCode/");
            return client.GetRequest("Reduction/" + uId).ExecuteAsync<Reduction>().Result;
        }
    }
}
