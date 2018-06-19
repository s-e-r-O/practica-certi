using Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace ECommerceAPI.Controllers
{
    public class StoreController : ApiController, IServices 
    {
        [HttpGet]
        [Route("api/store")]
        public HttpResponseMessage Get()
        {
            StoreService storeservice = new StoreService();
            List<Store> store = storeservice.Get();
            string storeJSON = JsonConvert.SerializeObject(store, Formatting.Indented);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(storeJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpGet]
        [Route("api/store/{id}")]
        public HttpResponseMessage Get(string id)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            string errormessage = "{\"error\": \"The element don't exist\"}";
            StoreService storeservice = new StoreService();
            Store[] stores = {
                new Store() { Name = "Only Cereals", Line1 = "Dream St.", Line2 = "Oakland", Phone=41204930 },
                new Store() { Name = "Games", Line1 = "Flying Av.", Line2 = "Pallet Town", Phone=12389499 },
                new Store() { Name = "Just for you", Line1 = "Blv. of Broken Dreams", Line2 = "Greenland", Phone=65415844 },
                new Store() { Name = "Techs", Line1 = "Bit St.", Line2 = "Silicon Valley", Phone=90028192 }
            };
            stores.ToList().ForEach(store1 => { storeservice.Create(store1); });
            List<Store> store = storeservice.Get();
            foreach(Store st in store)
            {
                if(st.Name == id)
                {
                    Store sto = st;
                    string storeJSON = JsonConvert.SerializeObject(sto, Formatting.Indented);
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent(storeJSON, Encoding.UTF8, "application/json");
                    break;
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    response.Content = new StringContent(errormessage, Encoding.UTF8, "application/json");
                }
            }
            return response;
        }

        [HttpPost]
        [Route("api/store")]
        public HttpResponseMessage Post(HttpRequestMessage request)
        {
            var body = request.Content.ReadAsStringAsync().Result;
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            string errormessage = "{\"error\": \"an error ocurred\"}";
            string error = "{\"error\": \"error\"}";
            string successmessage = "{\"success\": \"store posted\"}";
            try
            {
                String storeJSON = body;
                Store store = JsonConvert.DeserializeObject<Store>(body);
                StoreService ss = new StoreService();
                if (ss.Create(store))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent(successmessage, Encoding.UTF8, "application/json");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    response.Content = new StringContent(errormessage, Encoding.UTF8, "application/json");
                }
            }
            catch
            {
                response.Content = new StringContent(error, Encoding.UTF8, "application/json");
            }
            return response;
        }

        [HttpPut]
        [Route("api/store/{key}")]
        public HttpResponseMessage Put(string key, HttpRequestMessage request)
        {
            var body = request.Content.ReadAsStringAsync().Result;
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            try
            {
                Store store = JsonConvert.DeserializeObject<Store>(body);
                StoreService st = new StoreService();
                st.Get();
                if (st.Update(key, store))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent("Store Updated", Encoding.UTF8, "application/json");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    response.Content = new StringContent("An error has ocurred updating Store", Encoding.UTF8, "application/json");
                }
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                response.Content = new StringContent("Error", Encoding.UTF8, "application/json");
            }
            return response;
        }

        [HttpDelete]
        [Route("api/store/{id}")]
        public HttpResponseMessage Delete(string id)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            string errormessage = "{\"error\": \"An error has ocurred deleting the Store\"}";
            string error = "{\"error\": \"error\"}";
            string successmessage = "{\"success\": \"store deleted\"}";
            try
            {
                StoreService st = new StoreService();
                st.Get();
                if (st.Delete(id))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent(successmessage, Encoding.UTF8, "application/json");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    response.Content = new StringContent(errormessage, Encoding.UTF8, "application/json");
                }
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                response.Content = new StringContent(error, Encoding.UTF8, "application/json");

            }
            return response;
        }
    }
}
