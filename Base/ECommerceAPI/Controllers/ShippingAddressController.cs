using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using Base;
using Newtonsoft.Json;

namespace ECommerceAPI.Controllers
{
    public class ShippingAddressController : ApiController, IServices
    {
        [HttpGet]
        [Route("api/shippingaddress")]
        public HttpResponseMessage Get()
        {
            ShippingAddressService shippingaddressservice = new ShippingAddressService();
            List<ShippingAddress> sa = shippingaddressservice.Get();
            string shippingaddressJSON = JsonConvert.SerializeObject(sa, Formatting.Indented);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(shippingaddressJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpGet]
        [Route("api/shippingaddress/{id}")]
        public HttpResponseMessage Get(string id)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            string errormessage = "{\"error\": \"The element don't exist\"}";
            ShippingAddressService shippingaddressservice = new ShippingAddressService();
            List<ShippingAddress> sa = shippingaddressservice.Get();
            foreach (ShippingAddress st in sa)
            {
                if (st.Identifier == id)
                {
                    ShippingAddress shad = st;
                    string shippingaddressJSON = JsonConvert.SerializeObject(shad, Formatting.Indented);
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent(shippingaddressJSON, Encoding.UTF8, "application/json");
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
        [Route("api/shippingaddress")]
        public HttpResponseMessage Post(HttpRequestMessage request)
        {
            var body = request.Content.ReadAsStringAsync().Result;
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            string errormessage = "{\"error\": \"an error ocurred\"}";
            string error = "{\"error\": \"error\"}";
            string successmessage = "{\"success\": \"Shipping Address posted\"}";
            try
            {
                ShippingAddress shippingaddress = JsonConvert.DeserializeObject<ShippingAddress>(body);
                ShippingAddressService sas = new ShippingAddressService();
                if (sas.Create(shippingaddress))
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
        [Route("api/shippingaddress/{key}")]
        public HttpResponseMessage Put(string key, HttpRequestMessage request)
        {
            var body = request.Content.ReadAsStringAsync().Result;
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            string successmessage = "{\"success\": \"Shipping Address updated\"}";
            string errormessage = "{\"error\": \"an error ocurred\"}";
            string error = "{\"success\": \"Error\"}";
            try
            {
                ShippingAddress shippingaddress = JsonConvert.DeserializeObject<ShippingAddress>(body);
                ShippingAddressService sas = new ShippingAddressService();
                if (sas.Update(key, shippingaddress))
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

        [HttpDelete]
        [Route("api/shippingaddress/{id}")]
        public HttpResponseMessage Delete(string id)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            string errormessage = "{\"error\": \"An error has ocurred deleting the Shipping Address\"}";
            string error = "{\"error\": \"error\"}";
            string successmessage = "{\"success\": \"Shipping Address deleted\"}";
            try
            {
                ShippingAddressService sas = new ShippingAddressService();
                if (sas.Delete(id))
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
