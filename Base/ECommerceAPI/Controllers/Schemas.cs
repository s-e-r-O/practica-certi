using Base;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceAPI.Controllers
{
    public class Schemas
    {
        private static Schemas _instance;

        private Schemas()
        {
            JSchemaGenerator schemaGenerator = new JSchemaGenerator();
            schemaGenerator.ContractResolver = new CamelCasePropertyNamesContractResolver();

            ProductSchema = schemaGenerator.Generate(typeof(Product));
            CategorySchema = schemaGenerator.Generate(typeof(Category));
        }

        public static Schemas Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Schemas();
                }
                return _instance;
            }
        }

        public JSchema ProductSchema;
        public JSchema CategorySchema;
    }
}