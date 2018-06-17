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
        [Route("api/getstore")]
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
        [Route("api/getstore/{id}")]
        public HttpResponseMessage Get(string id)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            StoreService storeservice = new StoreService();
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
                    response.Content = new StringContent("The element don't exist", Encoding.UTF8, "application/json");
                }
            }
            return response;
        }

        [HttpPost]
        [Route("api/poststore")]
        public HttpResponseMessage Post(HttpRequestMessage request)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            try
            {
                String storeJSON = request.ToString();
                Store store = JsonConvert.DeserializeObject<Store>(storeJSON);
                StoreService ss = new StoreService();
                if (ss.Create(store))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent("Store created", Encoding.UTF8, "application/json");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    response.Content = new StringContent("An error has ocurred creating the store", Encoding.UTF8, "application/json");
                }
            }
            catch
            {
                response.Content = new StringContent("Error", Encoding.UTF8, "application/json");
            }
            return response;
        }

        [HttpPut]
        [Route("api/updatestore/{key}")]
        public HttpResponseMessage Put(string key, HttpRequestMessage request)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            try
            {
                Store store = JsonConvert.DeserializeObject<Store>(request.ToString());
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
        [Route("api/deletestore/{key}")]
        public HttpResponseMessage Delete(string id)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            try
            {
                StoreService st = new StoreService();
                st.Get();
                if (st.Delete(id))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent("Store deleted", Encoding.UTF8, "application/json");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    response.Content = new StringContent("An error has ocurred deleting the Store", Encoding.UTF8, "application/json");
                }
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                response.Content = new StringContent(("Error"), Encoding.UTF8, "application/json");

            }
            return response;
        }
    }
}
