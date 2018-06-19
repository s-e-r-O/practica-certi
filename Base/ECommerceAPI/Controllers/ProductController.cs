using Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
namespace ECommerceAPI.Controllers
{
    public class ProductController : ApiController, IServices
    {

        ProductService ps = new ProductService();
        string schemaJson = @"{
                'description' : 'This describes a product',
                'type': 'object',
                'properties': {
                    'Code': {'type':'string','required':true},
                    'Name': {'type':'string', 'required':true},
                    'Price': {'type':'number', 'required':true},
                    'Description': {'type':'string' , 'required':true},
                    'Type': {'type':'string','required':true},
                    'ShippingDeliveryType':{'type':'string','required':true},
                    'ImageURL':{'type':'string','required':true},
                    'Category':{
                                'type':'object',
                                'properties':{
                                                'Name':{'type':'string','required':true},
                                                'Description':{'type':'string','required':true}
                                             }
                                }
                } , 
                'additionalProperties': false
            }";

        [HttpGet]
        public HttpResponseMessage Get()
        {
            string jsonProducts = JsonConvert.SerializeObject(ps.Get(), Formatting.Indented);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(jsonProducts, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            var response = Request.CreateResponse(HttpStatusCode.BadRequest);
            string responseBody = "{ \"error\": \"A product with that ID does not exist.\"}";

            List<Product> myProducts = ps.Get();
            int index = myProducts.FindIndex(p => p.Code == id);

            if (index >= 0)
            {
                Product product = myProducts[index];
                response = Request.CreateResponse(HttpStatusCode.OK);
                responseBody = JsonConvert.SerializeObject(product, Formatting.Indented);
            }

            response.Content = new StringContent(responseBody, Encoding.UTF8, "application/json");
            return response;

        }

        [HttpPost]
        public HttpResponseMessage Post(HttpRequestMessage request)
        {
            var requestBody = request.Content.ReadAsStringAsync().Result;
            var response = Request.CreateResponse(HttpStatusCode.BadRequest);
            string responseBody = "{ \"error\": \"There was an error with the format of the object sent in the body.\"}";

            JSchema schema = JSchema.Parse(schemaJson);
            JObject product = JObject.Parse(requestBody);

            if (product.IsValid(schema))
            {
                Product myProduct = JsonConvert.DeserializeObject<Product>(requestBody);

                if (!(ps.Create(myProduct)))
                {
                    responseBody = "{ \"error\": \"That product is already on the list.\"}";
                }
                else
                {
                    responseBody = "{\"id\":\" " + myProduct.Code + "\"}";
                    response = Request.CreateResponse(HttpStatusCode.OK);
                }
                
            }

            response.Content = new StringContent(responseBody, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpPut]
        public HttpResponseMessage Put(string id , HttpRequestMessage request)
        {
            var requestBody = request.Content.ReadAsStringAsync().Result;
            var response = Request.CreateResponse(HttpStatusCode.BadRequest);
            string responseBody = "{ \"error\": \"There was an error with the format of the object sent in the body.\"}";

            JSchema schema = JSchema.Parse(schemaJson);
            JObject product = JObject.Parse(requestBody);

            if (product.IsValid(schema))
            {
                Product myProduct = JsonConvert.DeserializeObject<Product>(requestBody);

                if (!(ps.Update(id,myProduct)))
                {
                    responseBody = "{ \"error\": \"The ids doesnt match or the id doest not exist.\"}";
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    responseBody = "{\"id\":\" " + myProduct.Code + "\"}";
                }
            }

            response.Content = new StringContent(responseBody, Encoding.UTF8, "application/json");
            return response;

        }

        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            var response = Request.CreateResponse(HttpStatusCode.BadRequest);
            string responseBody = "{ \"error\": \"A product with that id does not exist.\"}";

            if(ps.Delete(id)) {
                response = Request.CreateResponse(HttpStatusCode.OK);
                responseBody = "{\"id\":\" " + id + "\"}";
            }

            response.Content = new StringContent(responseBody, Encoding.UTF8, "application/json");
            return response;
        }

    }
}
