using GoStyle.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;

namespace GoStyle.Services
{
    public class ReductionServices
    {
        private static ReductionServices _reductionServices;
        HttpClient _client;

        /// <summary>
        /// Constructeur de ReductionServices
        /// </summary>
        private ReductionServices()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://51.15.244.170:12053/QRCode/");
            _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("*/*"));
        }

        /// <summary>
        /// Récupère l'instance du singleton
        /// </summary>
        /// <returns> L'instance du singleton </returns>
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

        /// <summary>
        /// Récupère une réduction
        /// </summary>
        /// <param name="uId">L'id de la réduction</param>
        /// <returns>Une réduction</returns>
        public async Task<Reduction> GetReductionAsync(string uId)
        {
            // Blocking call! Program will wait here until a response is received or a timeout occurs.
            Reduction reduction = await _client.GetFromJsonAsync<Reduction>("Reduction/" + uId + "/");

            if (reduction != null)
            {
                return reduction;
            }
            else
            {
                return null;
            }
        }
    }
}
