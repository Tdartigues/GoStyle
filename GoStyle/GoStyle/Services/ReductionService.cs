using GoStyle.Models;
using Tiny.RestClient;
using System.Net.Http;
using System.Threading.Tasks;

namespace GoStyle.Services
{
    public class ReductionServices
    {
        private static ReductionServices _reductionServices;
        TinyRestClient _client;

        private ReductionServices()
        {
            _client = new TinyRestClient(new HttpClient(), "http://51.15.244.170:12053/QRCode/");
        }

        public static ReductionServices GetReductionServices()
        {
            if(_reductionServices is null)
            {
                _reductionServices = new ReductionServices();
                return _reductionServices;
            }else
            {
                return _reductionServices;
            }
        }
        public async Task<Reduction> GetReductionAsync(string uId)
        {
            return await _client.GetRequest("Reduction/" + uId).ExecuteAsync<Reduction>();
        }
    }
}
