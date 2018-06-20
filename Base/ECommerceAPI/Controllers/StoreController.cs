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
        public HttpResponseMessage Get(string id)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            string errormessage = "{\"error\": \"Not Store matches the id\"}";
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
                    response.Content = new StringContent(errormessage, Encoding.UTF8, "application/json");
                }
            }
            return response;
        }

        [HttpPost]
        public HttpResponseMessage Post(HttpRequestMessage request)
        {
            var body = request.Content.ReadAsStringAsync().Result;
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            string errormessage = "{\"error\": \"There was an error with the format of the object sent in the body\"}";
            string error = "{\"error\": \"There was an error creating the Store\"}";
            try
            {
                Store store = JsonConvert.DeserializeObject<Store>(body);
                StoreService ss = new StoreService();
                if (ss.Create(store))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent("{\"id\": \"" + store.Name+ "\"}", Encoding.UTF8, "application/json");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    response.Content = new StringContent(error, Encoding.UTF8, "application/json");
                }
            }
            catch
            {
                response.Content = new StringContent(errormessage, Encoding.UTF8, "application/json");
            }
            return response;
        }

        [HttpPut]
        public HttpResponseMessage Put(string id, HttpRequestMessage request)
        {
            var body = request.Content.ReadAsStringAsync().Result;
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            string errormessage = "{\"error\": \"Not Store matches the id\"}";
            string error = "{\"error\": \"There was an error with the format of the object sent in the body\"}";
            try
            {
                Store store = JsonConvert.DeserializeObject<Store>(body);
                StoreService st = new StoreService();
                if (st.Update(id, store))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent("{\"id\": \"" + id + "\"}", Encoding.UTF8, "application/json");
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

        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            string errormessage = "{\"error\": \"An error has ocurred deleting the Store\"}";
            string error = "{\"error\": \"There was an error with the parameter, it should be an unique identifier. \"}";
            try
            {
                StoreService st = new StoreService();
                if (st.Delete(id))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent("{\"id\": \"" + id + "\"}", Encoding.UTF8, "application/json");
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
