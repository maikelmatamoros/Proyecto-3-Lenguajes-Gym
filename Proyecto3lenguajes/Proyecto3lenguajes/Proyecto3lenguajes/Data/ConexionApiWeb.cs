using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Proyecto3lenguajes.Data
{
    public class ConexionApiWeb
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
                    String respuesta = await response.Content.ReadAsStringAsync();
                    String r1 = respuesta.Replace("\\", "");
                    string r2 = r1.Remove(0, 1);
                    string r4 = r2.Remove(r2.Length - 1);
                    return r4;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }


        public async Task<String> ObtenerHoras(String id, String fecha, String usuario)
        {
            HttpClient client = new HttpClient();
            Uri u = new Uri("https://localhost:44346/api/Usuarios/ObtenerOcupacion");
            var values = new Dictionary<string, string>();
            values.Add("id", id);
            values.Add("fecha", fecha);
            values.Add("usuario", usuario);
            var content = new FormUrlEncodedContent(values);

            try
            {
                HttpResponseMessage response = await client.PostAsync(u,content);
                if (response.IsSuccessStatusCode)
                {
                    String respuesta = await response.Content.ReadAsStringAsync();
                    return respuesta;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public async Task<String> ObtenerReservaciones(String usuario, String fecha1, String fecha2)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44346/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response = await client.GetAsync("Usuarios/ObtenerReservaciones?usuario=" + usuario + "&fecha1=" + fecha1 + "&fecha2=" + fecha2);
                if (response.IsSuccessStatusCode)
                {
                    String respuesta = await response.Content.ReadAsStringAsync();
                    String r1 = respuesta.Replace("\\", "");
                    string r2 = r1.Remove(0, 1);
                    string r4 = r2.Remove(r2.Length - 1);
                    return r4;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }


        public async Task<String> ObtenerClases()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44346/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response = await client.GetAsync("Usuarios/ObtenerClasesVirtuales");
                if (response.IsSuccessStatusCode)
                {
                    String respuesta = await response.Content.ReadAsStringAsync();
                    String r1 = respuesta.Replace("\\", "");
                    string r2 = r1.Remove(0, 1);
                    string r4 = r2.Remove(r2.Length - 1);
                    return r4;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }


        public async Task<String> ObtenerCentroInfoGenera(string id)
        {
            HttpClient client = new HttpClient();

            Uri u = new Uri("https://localhost:44346/api/Usuarios/ObtenerCentroInfo");
            var values = new Dictionary<string, string>();
            values.Add("id", id);
            var content = new FormUrlEncodedContent(values);


            try
            {
                HttpResponseMessage response = await client.PostAsync(u, content);
                if (response.IsSuccessStatusCode)
                {
                    String respuesta = await response.Content.ReadAsStringAsync();

                    return respuesta;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public async Task<String> ObtenerClases(string id)
        {
            HttpClient client = new HttpClient();

            Uri u = new Uri("https://localhost:44346/api/Usuarios/ObtenerClasesVirtuales");
            var values = new Dictionary<string, string>();
            values.Add("id", id);
            var content = new FormUrlEncodedContent(values);


            try
            {
                HttpResponseMessage response = await client.PostAsync(u, content);
                if (response.IsSuccessStatusCode)
                {
                    String respuesta = await response.Content.ReadAsStringAsync();
                    String r1 = respuesta.Replace("\\", "");
                    return r1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }



        public async Task<String> Login(int id, string userName, string pass)
        {
            HttpClient client = new HttpClient();

            Uri u = new Uri("https://localhost:44346/api/Usuarios/LoginToCentro");
            var payload = "{\"id\": " + id + ",\"userName\": \"" + userName + "\",\"password\": \"" + pass + "\"}";

            HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");
            try
            {
                HttpResponseMessage response = await client.PostAsync(u, c);
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

        public async Task<String> Reservar(int id, string userName)
        {
            HttpClient client = new HttpClient();

            Uri u = new Uri("https://localhost:44346/api/Usuarios/Reservar");
            var values = new Dictionary<string, string>();
            values.Add("idH", id.ToString());
            values.Add("usuario", userName);
            var content = new FormUrlEncodedContent(values);

            try
            {
                HttpResponseMessage response = await client.PostAsync(u, content);
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
