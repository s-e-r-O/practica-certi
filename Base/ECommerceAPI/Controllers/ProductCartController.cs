﻿using Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using Newtonsoft.Json.Serialization;
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
    public class ProductCartController : ApiController, IServices
    {

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpGet]        
        public HttpResponseMessage Get()
        {
            ProductCartService prodcartservice = new ProductCartService();
            List<ProductCart> pc = prodcartservice.Get();
            string prodcartJSON = JsonConvert.SerializeObject(pc, Formatting.Indented, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(prodcartJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpGet]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
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
                    string prodcartJSON = JsonConvert.SerializeObject(pdct, Formatting.Indented, new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    });
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
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage Post(HttpRequestMessage request)
        {
            var requestBody = request.Content.ReadAsStringAsync().Result;
            var response = Request.CreateResponse(HttpStatusCode.BadRequest);
            string responseBody = "{ \"error\": \"There was an error with the structure of the object sent in the body.\"}";
            try
            {
                ProductCart myProductCart = JsonConvert.DeserializeObject<ProductCart>(requestBody);
                CartService cs = new CartService();
                List < Cart > myCarts = cs.Get();
                int index = myCarts.FindIndex(cart => cart.Username == myProductCart.Username);
                if (index >= 0)
                {
                    ProductCartService pcs = new ProductCartService(myCarts[index]);
                    if (!(pcs.Create(myProductCart)))
                    {
                        responseBody = "{ \"error\": \"That product is already on the cart.\"}";
                    }
                    else
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK);
                        responseBody = "{\"id\":\" " + myProductCart.ProductCode + "\"}";
                    }
                }
                else
                {
                    if (cs.Create(new Cart { Username = myProductCart.Username }))
                    {
                        index = myCarts.FindIndex(cart => cart.Username == myProductCart.Username);
                        ProductCartService pcs = new ProductCartService(myCarts[index]);
                        if ((pcs.Create(myProductCart)))
                        {
                            response = Request.CreateResponse(HttpStatusCode.OK);
                            responseBody = "{\"id\":\" " + myProductCart.ProductCode + "\"}";
                        }
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
            string responseBody = "{ \"error\": \"There was an error with the structure of the object sent in the body.\"}";

            try
            {
                    ProductCart myProductCart = JsonConvert.DeserializeObject<ProductCart>(requestBody);
                    CartService cs = new CartService();
                    List<Cart> myCarts = cs.Get();
                    int index = myCarts.FindIndex(cart => cart.Username == myProductCart.Username);
                    if (index >= 0)
                    {
                        ProductCartService pcs = new ProductCartService(myCarts[index]);
                        if (!(pcs.Update(id,myProductCart)))
                        {
                            responseBody = "{ \"error\": \"That user doesnt have a cart.\"}";
                        }
                        else
                        {
                            response = Request.CreateResponse(HttpStatusCode.OK);
                            responseBody = "{\"id\":\" " + myProductCart.ProductCode + "\"}";
                        }
                    }
                    else
                    {
                        responseBody = "{ \"error\": \"That user doesnt have a cart.\"}";
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

            try
            {
                String[] auxString = id.Split('-');
                string productID = auxString[0];
                string username = auxString[1];

                CartService cs = new CartService();
                List<Cart> myCarts = cs.Get();
                int index = myCarts.FindIndex(cart => cart.Username == username);
                if (index >= 0)
                {
                    ProductCartService pcs = new ProductCartService(myCarts[index]);
                    if (!(pcs.Delete(productID)))
                    {
                        responseBody = "{ \"error\": \"That user doesnt have that product in the cart.\"}";
                    }
                    else
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK);
                        responseBody = "{\"id\":\" " + productID + "\"}";
                    }
                }
                else
                {
                    responseBody = "{ \"error\": \"That user doesnt have a cart.\"}";
                }
            }
            catch
            {
                responseBody = "{ \"error\": \"The id passed by URL should be productid-username.\"}";
            }
            response.Content = new StringContent(responseBody, Encoding.UTF8, "application/json");
            return response;
        }
    }
}