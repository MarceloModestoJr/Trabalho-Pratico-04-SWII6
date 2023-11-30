using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebAPI_SDK.Dtos;

//Marcelo Modesto de Lima Junior CB3015823
//Bruna Helena Silva Santos      CB3016111

namespace WebAPI_SDK.Services
{
    public class AtividadesService
    {
        private string baseUrl;
        private HttpClient client;
        public AtividadesService(string baseUrl, HttpClient client)
        {
            this.client = client;
            this.baseUrl = baseUrl;
        }

        public async Task<List<AtividadeDTO>> GetAll()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/atividades");

            var response = await client.SendAsync(request);

            var atividades = JsonConvert.DeserializeObject<List<AtividadeDTO>>(await response.Content.ReadAsStringAsync());

            return atividades;
        }

        public async Task<AtividadeDTO> GetById(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/atividades/{id}");

            var response = await client.SendAsync(request);

            var atividade = JsonConvert.DeserializeObject<AtividadeDTO>(await response.Content.ReadAsStringAsync());

            return atividade;
        }     

        public async Task<bool> Create(AtividadeDTO atividade)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{baseUrl}/atividades");

            var content = JsonConvert.SerializeObject(atividade);

            request.Content = new StringContent(content, null, "application/json");
            var response = await client.SendAsync(request);

            return response.StatusCode == HttpStatusCode.Created;
        }

        public async Task<bool> Update(int id, AtividadeDTO atividade)
        {

            var request = new HttpRequestMessage(HttpMethod.Put, $"{baseUrl}/atividades/{id}");

            var content = JsonConvert.SerializeObject(atividade);

            request.Content = new StringContent(content, null, "application/json");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return response.StatusCode == HttpStatusCode.NoContent;
        }

        public async Task<bool> Delete(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{baseUrl}/atividades/{id}");

            var response = await client.SendAsync(request);

            return response.StatusCode == HttpStatusCode.NoContent;
        }

    }
}
