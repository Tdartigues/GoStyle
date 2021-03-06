using GoStyle.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Collections.ObjectModel;

namespace GoStyle.Services
{
    public class ReductionServices
    {
        private static ReductionServices _reductionServices;
        HttpClient _client;
        ObservableCollection<Reduction> _reductions = new ObservableCollection<Reduction>();

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
        public static ReductionServices GetInstance()
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
            reduction.textTaux = reduction.taux.ToString() + '%';
            if (reduction != null)
            {
                return reduction;
            }
            else
            {
                return reduction;
            }
        }

        public void SetTocken (String token)
        {
            _client.DefaultRequestHeaders.Add("Authorization", "token " + token);
        }

        public void RmTocken()
        {
            _client.DefaultRequestHeaders.Remove("Authorization");
        }

        public ObservableCollection<Reduction> GetReductions()
        {
            return _reductions;
        }
    }
}
