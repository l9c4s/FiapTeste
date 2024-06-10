using FrontEnd.Fiap.Request.Interface;
using Newtonsoft;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
namespace FrontEnd.Fiap.Request.Repositorio
{
    public class RequestRepositorio : IRequest
    {
        private readonly HttpClient _httpClient;
        private readonly string _url;
        public RequestRepositorio() { 
            _httpClient = new HttpClient();
            _url = "http://localhost:5093/api/";
        }



        public Task<T> DeleteAsync<T>(T entidade, string Endpoint)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<T?>> GetAsync<T>(string Endpoint)
         {
            try
            {

                var Entidade = await _httpClient.GetAsync(_url+Endpoint);

                if (Entidade.IsSuccessStatusCode)
                {
                    var JsonString = await Entidade.Content.ReadAsStringAsync();
                    List<T> Convertido = JsonConvert.DeserializeObject<List<T>>(JsonString);
                     var Retorno = Convertido.AsQueryable();
                    return Retorno;
                }

                return default(IQueryable<T>);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<T> GetByIdAsync<T>(string Endpoint, int id)
        {
            try
            {
                string json = JsonConvert.SerializeObject(id);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string all = _url + Endpoint;

                var Resposta = await _httpClient.PostAsync(all,content);

                if (Resposta.IsSuccessStatusCode)
                {
                    var JsonString = await Resposta.Content.ReadAsStringAsync();

                    T Convertido = JsonConvert.DeserializeObject<T>(JsonString);
                    if (Convertido != null)
                    {
                        return Convertido;
                    }

                    return default(T);
                }
                return default(T);
            }
            catch (Exception e) {
                throw new NotImplementedException();

            }
        }

        public async Task<T> PostAsync<T>(T Entidade, string Endpoint)
        {
            string json = JsonConvert.SerializeObject(Entidade);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string all = _url + Endpoint;

            var Resposta = await _httpClient.PostAsync(all, content);

            if (Resposta.IsSuccessStatusCode)
            {
                var JsonString = await Resposta.Content.ReadAsStringAsync();


                bool Convertido = JsonConvert.DeserializeObject<bool>(JsonString);
                if (Convertido) {
                    return Entidade;
                }
                return default(T);
            }

            return default(T);
        }

        public async Task<bool> PostAsyncBool(string Dado, string Endpoint)
        {

            string json = JsonConvert.SerializeObject(Dado);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string all = _url + Endpoint;

            var Resposta = await _httpClient.PostAsync(all, content);

            if (Resposta.IsSuccessStatusCode)
            {
                var JsonString = await Resposta.Content.ReadAsStringAsync();


                bool Convertido = JsonConvert.DeserializeObject<bool>(JsonString);
                if (Convertido)
                {
                    return Convertido;
                }
            }
            return false;
        }

        public async Task<T> PostWithIdAsync<T>(int id, string Endpoint)
        {
            string json = JsonConvert.SerializeObject(id);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string all = _url + Endpoint;

            var Resposta = await _httpClient.PostAsync(all, content);

            if (Resposta.IsSuccessStatusCode)
            {
                var JsonString = await Resposta.Content.ReadAsStringAsync();


                T Convertido = JsonConvert.DeserializeObject<T>(JsonString);
                if (Convertido != null)
                {
                    return Convertido;
                }
                return default(T);
            }

            return default(T);
        }

        public async Task<T> PutAsync<T>(T Entidade, string Endoint)
        {
            string json = JsonConvert.SerializeObject(Entidade);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string all = _url + Endoint;

            var Resposta = await _httpClient.PutAsync(all, content);

            if (Resposta.IsSuccessStatusCode)
            {
                var JsonString = await Resposta.Content.ReadAsStringAsync();


                bool Convertido = JsonConvert.DeserializeObject<bool>(JsonString);
                if (Convertido)
                {
                    return Entidade;
                }

                return default(T);
            }
            return default(T);
        }
    }
}
