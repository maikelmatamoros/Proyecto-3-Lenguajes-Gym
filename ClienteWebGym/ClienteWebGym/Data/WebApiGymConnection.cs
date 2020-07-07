using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text;

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

        public async Task<String> ObtenerHoras(String id,String fecha)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44346/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response = await client.GetAsync("Usuarios/ObtenerOcupacion?id="+id+"&fecha="+fecha);
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

        public async Task<String> Login(int id,string userName,string pass)
        {
            HttpClient client = new HttpClient();

            Uri u = new Uri("https://localhost:44346/api/Usuarios/LoginToCentro");
            var payload = "{\"id\": "+id+",\"userName\": \""+userName+"\",\"password\": \""+pass+"\"}";

            HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");
            try
            {
                HttpResponseMessage response = await client.PostAsync(u,c);
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
