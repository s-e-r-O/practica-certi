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

namespace ECommerceAPI.Controllers
{
    public class CategoryController : ApiController
    {

        CategoryService cs = new CategoryService();
        JSchemaGenerator schemaGenerator = new JSchemaGenerator();

        [HttpGet]
        public HttpResponseMessage Get()
        {
            string jsonCategorys = JsonConvert.SerializeObject(cs.Get(), Formatting.Indented);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(jsonCategorys, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            var response = Request.CreateResponse(HttpStatusCode.BadRequest);
            string responseBody = "{ \"error\": \"A Category with that ID does not exist.\"}";

            List<Category> myCategorys = cs.Get();
            int index = myCategorys.FindIndex(c => c.Name == id);

            if (index >= 0)
            {
                Category category = myCategorys[index];
                response = Request.CreateResponse(HttpStatusCode.OK);
                responseBody = JsonConvert.SerializeObject(category, Formatting.Indented);
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

            JSchema schema = schemaGenerator.Generate(typeof(Category));
            schema.AllowAdditionalProperties = false;

            JObject category = JObject.Parse(requestBody);

            if (category.IsValid(schema))
            {
                Category myCategory = JsonConvert.DeserializeObject<Category>(requestBody);

                if (!(cs.Create(myCategory)))
                {
                    responseBody = "{ \"error\": \"That category is already on the list.\"}";
                }
                else
                {
                    responseBody = "{\"id\":\" " + myCategory.Name + "\"}";
                    response = Request.CreateResponse(HttpStatusCode.OK);
                }

            }

            response.Content = new StringContent(responseBody, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpPut]
        public HttpResponseMessage Put(string id, HttpRequestMessage request)
        {
            var requestBody = request.Content.ReadAsStringAsync().Result;
            var response = Request.CreateResponse(HttpStatusCode.BadRequest);
            string responseBody = "{ \"error\": \"There was an error with the format of the object sent in the body.\"}";

            JSchema schema = schemaGenerator.Generate(typeof(Category));
            schema.AllowAdditionalProperties = false;

            JObject category = JObject.Parse(requestBody);

            if (category.IsValid(schema))
            {
                Category myCategory = JsonConvert.DeserializeObject<Category>(requestBody);

                if (!(cs.Update(id, myCategory)))
                {
                    responseBody = "{ \"error\": \"The ids doesnt match or the id doest not exist.\"}";
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    responseBody = "{\"id\":\" " + myCategory.Name + "\"}";
                }
            }

            response.Content = new StringContent(responseBody, Encoding.UTF8, "application/json");
            return response;

        }

        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            var response = Request.CreateResponse(HttpStatusCode.BadRequest);
            string responseBody = "{ \"error\": \"A category with that id does not exist.\"}";

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
