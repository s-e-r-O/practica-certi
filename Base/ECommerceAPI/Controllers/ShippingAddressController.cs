using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using Base;
using Newtonsoft.Json;
using System.Web.Http.Cors;

namespace ECommerceAPI.Controllers
{
    public class ShippingAddressController : ApiController, IServices
    {
        [HttpGet]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
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
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage Get(string id)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            string errormessage = "{\"error\": \"Not Shipping Address matches the id\"}";
            ShippingAddressService shippingaddressservice = new ShippingAddressService();
            List<ShippingAddress> sa = shippingaddressservice.Get();
            List<ShippingAddress> shad = new List<ShippingAddress>();
            foreach (ShippingAddress st in sa)
            {
                if (st.Username == id)
                {

                    shad.Add(st);
                    string shippingaddressJSON = JsonConvert.SerializeObject(shad, Formatting.Indented);
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent(shippingaddressJSON, Encoding.UTF8, "application/json");
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
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage Post(HttpRequestMessage request)
        {
            var body = request.Content.ReadAsStringAsync().Result;
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            string errormessage = "{\"error\": \"There was an error with the format of the object sent in the body\"}";
            string error = "{\"error\": \"There was an error creating the ShippingAddress\"}";
            try
            {
                User user = new User();
                UserService userservice = new UserService();
                List<User> users = userservice.Get();
                ShippingAddress shippingaddress = JsonConvert.DeserializeObject<ShippingAddress>(body);
                string username = shippingaddress.Username;
                foreach (User us in users)
                {
                    if (us.Username == username)
                    {
                        user = us;
                    }
                    else
                    {
                        response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                        response.Content = new StringContent(errormessage, Encoding.UTF8, "application/json");
                    }
                }

                ShippingAddressService sas = new ShippingAddressService();
                sas.User = user;

                if (sas.Create(shippingaddress))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent("{\"id\": \"" + shippingaddress.Identifier + "\"}", Encoding.UTF8, "application/json");
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
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage Put(string id, HttpRequestMessage request)
        {
            var body = request.Content.ReadAsStringAsync().Result;
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            string errormessage = "{\"error\": \"Not Shipping Address matches the id\"}";
            string error = "{\"error\": \"There was an error with the format of the object sent in the body\"}";
            try
            {
                User user = new User();
                UserService userservice = new UserService();
                List<User> users = userservice.Get();
                ShippingAddress shippingaddress = JsonConvert.DeserializeObject<ShippingAddress>(body);
                ShippingAddressService sas = new ShippingAddressService();
                string username = shippingaddress.Username;
                foreach (User us in users)
                {
                    if (us.Username == username)
                    {
                        user = us;
                    }
                    else
                    {
                        response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                        response.Content = new StringContent(errormessage, Encoding.UTF8, "application/json");
                    }
                }
                sas.User = user;
                if (sas.Update(id, shippingaddress))
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
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage Delete(string id)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            string errormessage = "{\"error\": \"An error has ocurred deleting the Shipping Address\"}";
            string error = "{\"error\": \"There was an error with the parameter, it should be an unique identifier. \"}";
            try
            {
                ShippingAddressService sas = new ShippingAddressService();
                if (sas.Delete(id))
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
