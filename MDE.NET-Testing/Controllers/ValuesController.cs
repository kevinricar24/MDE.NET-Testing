using System.Collections.Generic;
using System.Web.Http;

namespace MDE.NET_Testing.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {

        Dictionary<int, string> Data = new Dictionary<int, string>()
        {
            { 0, "value0" }, { 1, "value1" }, {2, "value2" }
        };

        public string GetData(int id)
        {
            string result = string.Empty;
            foreach (var item in Data)
            {
                if (item.Key.Equals(id))
                {
                    result = item.Value;
                }
            }
            return result;
        }

        // GET api/values
        public Dictionary<int, string> Get()
        {
            return Data;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return GetData(id);
        }

        // POST api/values
        public string Post([FromBody]string value)
        {
            string result = string.Empty;
            int LastData = Data.Count + 1;
            Data.Add(LastData, value);
            result = value + " added!";
            return result;
        }

        // PUT api/values/5
        public string Put(int id, [FromBody]string value)
        {
            string result = string.Empty;
            Data.Add(id, value);
            result = value + " updated!";
            return result;
        }

        // DELETE api/values/5
        public string Delete(int id)
        {
            string result = string.Empty;
            string value = GetData(id);
            Data.Remove(id);
            result = id + " removed!";
            return result;
        }
    }
}
