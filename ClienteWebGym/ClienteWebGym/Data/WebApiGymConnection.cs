using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace ClienteWebGym.Data
{
    public class WebApiGymConnection
    {
        public async Task<String> ObtenerCentros()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44346/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response = await client.GetAsync("Usuarios/GetCentros");
                if (response.IsSuccessStatusCode)
                {
                    String respuesta = await response.Content.ReadAsStringAsync(); ;

                    return respuesta;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}
