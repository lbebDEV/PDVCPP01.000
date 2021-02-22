using Newtonsoft.Json;
using PDVCPP01._000.Config;
using PDVCPP01._000.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PDVCPP01._000.HttpClients
{
    public class HttpClientBase<T> where T : class
    {
        protected readonly HttpClient _client;

        public HttpClientBase(string url)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(url);
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void InsertToken()
        {
            _client.DefaultRequestHeaders.Add("token", Service_Config.Token);
        }

        public T Get(string path)
        {
            string dataInicial = "";
            if (Service_Config.DataRetrocesso != "0")
                dataInicial = DateTime.Now.AddDays(Convert.ToDouble(Service_Config.DataRetrocesso)).ToString("dd/MM/yyyy");
            else
                dataInicial = DateTime.Now.ToString("dd/MM/yyyy");

            string dataFinal = DateTime.Now.ToString("dd/MM/yyyy");

            UriBuilder builder = new UriBuilder("https://painel.velocepdv.com.br/" + path);
            builder.Query = "dt_inicial="+ dataInicial + "&dt_final=" + dataFinal + "";
            var response = _client.GetStringAsync(builder.Uri).Result;
            var entity = JsonConvert.DeserializeObject<T>(response);
            return entity;
        }

        public List<T> GetAll(string path)
        {
            var response = _client.GetStringAsync(path).Result;
            var entities = JsonConvert.DeserializeObject<List<T>>(response);

            return entities;
        }

        public async Task<string> Post(string path, T obj)
        {
            var entity = JsonConvert.SerializeObject(obj);
            var data = new StringContent(entity, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(path, data);

            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
