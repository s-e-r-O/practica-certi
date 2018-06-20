using Base;
using ECommerceAPI.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace ECommerceAPI
{
    public class UserController : ApiController, IServices
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            UserService userservice = new UserService();
            List<User> user = userservice.Get();
            string UserJSON = JsonConvert.SerializeObject(user, Formatting.Indented);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(UserJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            string errormessage = "{\"error\": \"The element don't exist\"}";
            UserService userservice = new UserService();
            List<User> User = userservice.Get();
            foreach (User st in User)
            {
                if (st.Name == id)
                {
                    User sto = st;
                    string UserJSON = JsonConvert.SerializeObject(sto, Formatting.Indented);
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent(UserJSON, Encoding.UTF8, "application/json");
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
            string errormessage = "{\"error\": \"an error ocurred\"}";
            string error = "{\"error\": \"error\"}";
            string successmessage = "{\"success\": \"User posted\"}";
            try
            {
                User user = JsonConvert.DeserializeObject<User>(body);
                UserService ss = new UserService();
                if (ss.Create(user))
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
        public HttpResponseMessage Put(string key, HttpRequestMessage request)
        {
            var body = request.Content.ReadAsStringAsync().Result;
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            string successmessage = "{\"success\": \"User updated\"}";
            string errormessage = "{\"error\": \"an error ocurred\"}";
            string error = "{\"error\": \"Error\"}";
            try
            {
                User user = JsonConvert.DeserializeObject<User>(body);
                UserService st = new UserService();
                if (st.Update(key, user))
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
        public HttpResponseMessage Delete(string id)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            string errormessage = "{\"error\": \"An error has ocurred deleting the User\"}";
            string error = "{\"error\": \"error\"}";
            string successmessage = "{\"success\": \"User deleted\"}";
            try
            {
                UserService st = new UserService();
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