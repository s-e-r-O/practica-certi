using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Controllers
{
    public interface IServices
    {
        HttpResponseMessage Get(string id);
        HttpResponseMessage Get();
        HttpResponseMessage Post(HttpRequestMessage request);
        HttpResponseMessage Put(HttpRequestMessage request);
        HttpResponseMessage Delete(string id);
    }
}
