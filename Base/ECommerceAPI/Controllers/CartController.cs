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
    public class CartController : ApiController, IServices
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            ProductCartService prodcartservice = new ProductCartService();
            List<ProductCart> pc = prodcartservice.Get();
            string prodcartJSON = JsonConvert.SerializeObject(pc, Formatting.Indented);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(prodcartJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            ProductCartService prodcartservice = new ProductCartService();
            List<ProductCart> pc = prodcartservice.Get();
            foreach (ProductCart pt in pc)
            {
                if (pt.ProductCode == id)
                {
                    ProductCart pdct = pt;
                    string prodcartJSON = JsonConvert.SerializeObject(pdct, Formatting.Indented);
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent(prodcartJSON, Encoding.UTF8, "application/json");
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
        public HttpResponseMessage Post(HttpRequestMessage request)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            try
            {
                String prodcartJSON = request.ToString();
                ProductCart prodcart = JsonConvert.DeserializeObject<ProductCart>(prodcartJSON);
                ProductCartService pcs = new ProductCartService();
                if (pcs.Create(prodcart))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent("Product Cart created", Encoding.UTF8, "application/json");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    response.Content = new StringContent("An error has ocurred creating Product Cart", Encoding.UTF8, "application/json");
                }
            }
            catch
            {
                response.Content = new StringContent("Error", Encoding.UTF8, "application/json");
            }
            return response;
        }

        [HttpPut]
        public HttpResponseMessage Put(string key, HttpRequestMessage request)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            try
            {
                ProductCart prodcart = JsonConvert.DeserializeObject<ProductCart>(request.ToString());
                ProductCartService pcs = new ProductCartService();
                pcs.Get();
                if (pcs.Update(key, prodcart))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent("Product Cart Updated", Encoding.UTF8, "application/json");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    response.Content = new StringContent("An error has ocurred updating Product Cart", Encoding.UTF8, "application/json");
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
        public HttpResponseMessage Delete(string id)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            try
            {
                ProductCartService pcs = new ProductCartService();
                pcs.Get();
                if (pcs.Delete(id))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent("Product Cart deleted", Encoding.UTF8, "application/json");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    response.Content = new StringContent("An error has ocurred deleting the Product Cart", Encoding.UTF8, "application/json");
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