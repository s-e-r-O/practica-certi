using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public interface Crudable
    {
        bool Create(Object obj);
        List<Object> Get();
        bool Update(String key, Object obj);
        bool Delete(String key);
    }
}
