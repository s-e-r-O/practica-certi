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
                    response.Content = new StringContent("The element don't exist", Encoding.UTF8, "application/json");
                }
            }
            return response;
        }

        [HttpPost]
        [Route("api/shippingaddress")]
        public HttpResponseMessage Post(HttpRequestMessage request)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            try
            {
                String shippingaddressJSON = request.ToString();
                ShippingAddress shippingaddress = JsonConvert.DeserializeObject<ShippingAddress>(shippingaddressJSON);
                ShippingAddressService sas = new ShippingAddressService();
                if (sas.Create(shippingaddress))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent("Shipping Address created", Encoding.UTF8, "application/json");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    response.Content = new StringContent("An error has ocurred creating the shipping address", Encoding.UTF8, "application/json");
                }
            }
            catch
            {
                response.Content = new StringContent("Error", Encoding.UTF8, "application/json");
            }
            return response;
        }

        [HttpPut]
        [Route("api/shippingaddress/{key}")]
        public HttpResponseMessage Put(string key, HttpRequestMessage request)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            try
            {
                ShippingAddress shippingaddress = JsonConvert.DeserializeObject<ShippingAddress>(request.ToString());
                ShippingAddressService sas = new ShippingAddressService();
                sas.Get();
                if (sas.Update(key, shippingaddress))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent("Shipping Address Updated", Encoding.UTF8, "application/json");
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
        [Route("api/shippingaddress/{id}")]
        public HttpResponseMessage Delete(string id)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            try
            {
                ShippingAddressService sas = new ShippingAddressService();
                sas.Get();
                if (sas.Delete(id))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent("Shipping Address deleted", Encoding.UTF8, "application/json");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    response.Content = new StringContent("An error has ocurred deleting the Shipping Store", Encoding.UTF8, "application/json");
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
