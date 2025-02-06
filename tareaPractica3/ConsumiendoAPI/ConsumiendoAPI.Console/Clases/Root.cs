using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumiendoAPI.Console.Clases
{
    public class Root
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public List<Result> results { get; set; }
        public Info info { get; set; }
    }
}
