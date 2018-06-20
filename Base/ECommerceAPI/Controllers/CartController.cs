using Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ECommerceAPI.Controllers
{
    public class CartController : ApiController, IServices
    {
        CartService cs = new CartService();
        JSchemaGenerator schemaGenerator = new JSchemaGenerator();

        [HttpGet]
        [EnableCors(origins: "http://localhost:4200",headers:"*",methods:"*")]
        public HttpResponseMessage Get()
        {
            string jsonCarts = JsonConvert.SerializeObject(cs.Get(), Formatting.Indented);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(jsonCarts, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpGet]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage Get(string id)
        {
            var response = Request.CreateResponse(HttpStatusCode.BadRequest);
            string responseBody = "{ \"error\": \"That user does not have a cart.\"}";

            List<Cart> myCarts = cs.Get();
            int index = myCarts.FindIndex(c=> c.Username == id);

            if (index >= 0)
            {
                Cart cart = myCarts[index];
                response = Request.CreateResponse(HttpStatusCode.OK);
                responseBody = JsonConvert.SerializeObject(cart, Formatting.Indented);
            }

            response.Content = new StringContent(responseBody, Encoding.UTF8, "application/json");
            return response;

        }

        [HttpPost]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage Post(HttpRequestMessage request)
        {
            var requestBody = request.Content.ReadAsStringAsync().Result;
            var response = Request.CreateResponse(HttpStatusCode.BadRequest);
            string responseBody = "{ \"error\": \"There was an error with the structure of the object sent in the body.\"}";

            JSchema schema = schemaGenerator.Generate(typeof(Cart));
            schema.AllowAdditionalProperties = false;

            try
            {
                JObject jsonCart = JObject.Parse(requestBody);
                if (jsonCart.IsValid(schema))
                {
                    Cart myCart = JsonConvert.DeserializeObject<Cart>(requestBody);

                    if (!(cs.Create(myCart)))
                    {
                        responseBody = "{ \"error\": \"That user already has a cart.\"}";
                    }
                    else
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK);
                        responseBody = "{\"id\":\" " + myCart.Username + "\"}";
                    }
                }
            }
            catch
            {
                responseBody = "{ \"error\": \"The body of the request is not a valid json format.\"}";
            }

            response.Content = new StringContent(responseBody, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpPut]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage Put(string id, HttpRequestMessage request)
        {
            var requestBody = request.Content.ReadAsStringAsync().Result;
            var response = Request.CreateResponse(HttpStatusCode.BadRequest);
            string responseBody = "{ \"error\": \"There was an error with the format of the object sent in the body.\"}";

            JSchema schema = schemaGenerator.Generate(typeof(Cart));
            schema.AllowAdditionalProperties = false;

            try
            {
                JObject jsonCart = JObject.Parse(requestBody);

                if (jsonCart.IsValid(schema))
                {
                    Cart myCart = JsonConvert.DeserializeObject<Cart>(requestBody);

                    if (!(cs.Update(id, myCart)))
                    {
                        responseBody = "{ \"error\": \"The ids doesnt match or the id doest not exist.\"}";
                    }
                    else
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK);
                        responseBody = "{\"id\":\" " + myCart.Username + "\"}";
                    }
                }
            }
            catch
            {
                responseBody = "{ \"error\": \"The body of the request is not a valid json format.\"}";
            }

            response.Content = new StringContent(responseBody, Encoding.UTF8, "application/json");
            return response;

        }

        [HttpDelete]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage Delete(string id)
        {
            var response = Request.CreateResponse(HttpStatusCode.BadRequest);
            string responseBody = "{ \"error\": \"A product with that id does not exist.\"}";

            if (cs.Delete(id))
            {
                response = Request.CreateResponse(HttpStatusCode.OK);
                responseBody = "{\"id\":\" " + id + "\"}";
            }

            response.Content = new StringContent(responseBody, Encoding.UTF8, "application/json");
            return response;
        }
    }
}