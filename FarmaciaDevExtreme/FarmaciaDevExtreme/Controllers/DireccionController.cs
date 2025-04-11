using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using FarmaciaDevExtreme.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;

namespace FarmaciaDevExtreme.Controllers
{
    public class DireccionController : ApiController
    {
        private static readonly HttpClient client = new HttpClient();
        [HttpGet]
        public async Task<HttpResponseMessage> Get(DataSourceLoadOptions
        loadOptions)
        {
            var apiUrl = "https://localhost:44329/api/Direccions/";
            var respuestaJson = await GetAsync(apiUrl);
            //System.Diagnostics.Debug.WriteLine(respuestaJson);

            List<Direccion> listaDireccion = JsonConvert.DeserializeObject<List<Direccion>>(respuestaJson);
            return
            Request.CreateResponse(DataSourceLoader.Load(listaDireccion, loadOptions));
        }
        public static async Task<string> GetAsync(string uri)
        {
            var response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post(FormDataCollection form)
        {
            var values = form.Get("values");
            var httpContent = new StringContent(values,
            System.Text.Encoding.UTF8, "application/json");
            var url = "https://localhost:44329/api/Direccions/";
            var response = await client.PostAsync(url, httpContent);
            var result = response.Content.ReadAsStringAsync().Result;
            return Request.CreateResponse(HttpStatusCode.Created);
        }



        [HttpPut]
        public async Task<HttpResponseMessage> Put(FormDataCollection
        form)
        {
            //Parámetros del form
            var key = Convert.ToInt32(form.Get("key")); //llave que estoy modificando
            var values = form.Get("values"); //Los valores que yo modifiqué en formato JSON
            var apiUrlGetPeli = "https://localhost:44329/api/Direccions/" + key;
            var respuestaPelic = await GetAsync(apiUrlGetPeli = "https://localhost:44329/api/Direccions/" + key);
            Direccion direcicon = JsonConvert.DeserializeObject<Direccion>(respuestaPelic);
            JsonConvert.PopulateObject(values, direcicon);
            string jsonString = JsonConvert.SerializeObject(direcicon);
            var httpContent = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
            var url = "https://localhost:44329/api/Direccions/" + key;
            var response = await client.PutAsync(url, httpContent);
            var result = response.Content.ReadAsStringAsync().Result;
            return Request.CreateResponse(HttpStatusCode.OK);
        }



        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(FormDataCollection form)
        {
            var key = Convert.ToInt32(form.Get("key"));
            var apiUrlDelPeli = "https://localhost:44329/api/Direccions/"
                + key;
            var respuestaPelic = await
            client.DeleteAsync(apiUrlDelPeli);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
