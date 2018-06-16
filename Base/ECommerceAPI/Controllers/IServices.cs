using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Controllers
{
    public interface IServices
    {
        HttpResponseMessage Get(int id);
        HttpResponseMessage Get();
        HttpResponseMessage Post(Object content);
        HttpResponseMessage Put(Object res);
        HttpResponseMessage Delete(Object id);
    }
}
